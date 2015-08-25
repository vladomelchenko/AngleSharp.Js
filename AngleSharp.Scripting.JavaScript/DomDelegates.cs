﻿namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom;
    using Jint.Native;
    using Jint.Native.Function;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    static class DomDelegates
    {
        public static Delegate ToDelegate(this Type type, FunctionInstance function, EngineInstance engine)
        {
            if (type == typeof(DomEventHandler))
                return function.ToListener(engine);

            var method = typeof(DomDelegates).GetMethod("ToCallback").MakeGenericMethod(type);
            return method.Invoke(null, new Object[] { function }) as Delegate;
        }

        public static DomEventHandler ToListener(this FunctionInstance function, EngineInstance engine)
        {
            return (obj, ev) =>
            {
                function.Call(obj.ToJsValue(engine), new [] { ev.ToJsValue(engine) });
            };
        }

        public static T ToCallback<T>(this FunctionInstance function)
        {
            var type = typeof(T);
            var methodInfo = type.GetMethod("Invoke");
            var convert = typeof(Extensions).GetMethod("ToJsValue");
            var mps = methodInfo.GetParameters();
            var parameters = new ParameterExpression[mps.Length];

            for (var i = 0; i < mps.Length; i++)
                parameters[i] = Expression.Parameter(mps[i].ParameterType, mps[i].Name);

            var obj = Expression.Constant(function);
            var engine = Expression.Property(obj, "Engine");
            var call = Expression.Call(obj, "Call", new Type[0], new Expression[]
            {
                Expression.Call(convert, parameters[0], engine),
                Expression.NewArrayInit(typeof(JsValue), parameters.Skip(1).Select(m => Expression.Call(convert, m, engine)).ToArray())
            });

            return Expression.Lambda<T>(call, parameters).Compile();
        }
    }
}
