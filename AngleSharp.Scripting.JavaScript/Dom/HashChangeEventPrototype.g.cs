namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Events;
    using Jint;
    using Jint.Native;
    using Jint.Native.Object;
    using Jint.Runtime;
    using Jint.Runtime.Descriptors;
    using Jint.Runtime.Interop;
    using System;

    sealed partial class HashChangeEventPrototype : HashChangeEventInstance
    {
        readonly EngineInstance _engine;

        public HashChangeEventPrototype(EngineInstance engine)
            : base(engine)
        {
            _engine = engine;
            FastAddProperty("toString", Engine.AsValue(ToString), true, true, true);
            FastAddProperty("initHashChangedEvent", Engine.AsValue(InitHashChangedEvent), true, true, true);
            FastAddProperty("stopPropagation", Engine.AsValue(StopPropagation), true, true, true);
            FastAddProperty("stopImmediatePropagation", Engine.AsValue(StopImmediatePropagation), true, true, true);
            FastAddProperty("preventDefault", Engine.AsValue(PreventDefault), true, true, true);
            FastAddProperty("initEvent", Engine.AsValue(InitEvent), true, true, true);
            FastSetProperty("oldURL", Engine.AsProperty(GetOldURL));
            FastSetProperty("newURL", Engine.AsProperty(GetNewURL));
            FastSetProperty("type", Engine.AsProperty(GetType));
            FastSetProperty("target", Engine.AsProperty(GetTarget));
            FastSetProperty("currentTarget", Engine.AsProperty(GetCurrentTarget));
            FastSetProperty("eventPhase", Engine.AsProperty(GetEventPhase));
            FastSetProperty("bubbles", Engine.AsProperty(GetBubbles));
            FastSetProperty("cancelable", Engine.AsProperty(GetCancelable));
            FastSetProperty("defaultPrevented", Engine.AsProperty(GetDefaultPrevented));
            FastSetProperty("isTrusted", Engine.AsProperty(GetIsTrusted, SetIsTrusted));
            FastSetProperty("timeStamp", Engine.AsProperty(GetTimeStamp));
        }

        public static HashChangeEventPrototype CreatePrototypeObject(EngineInstance engine, HashChangeEventConstructor constructor)
        {
            var obj = new HashChangeEventPrototype(engine)
            {
                Prototype = engine.Constructors.Event.PrototypeObject,
                Extensible = true,
            };
            obj.FastAddProperty("constructor", constructor, true, false, true);
            return obj;
        }

        JsValue InitHashChangedEvent(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            var type = TypeConverter.ToString(arguments.At(0));
            var bubbles = TypeConverter.ToBoolean(arguments.At(1));
            var cancelable = TypeConverter.ToBoolean(arguments.At(2));
            var previousUrl = TypeConverter.ToString(arguments.At(3));
            var currentUrl = TypeConverter.ToString(arguments.At(4));
            reference.Init(type, bubbles, cancelable, previousUrl, currentUrl);
            return JsValue.Undefined;
        }

        JsValue StopPropagation(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            reference.Stop();
            return JsValue.Undefined;
        }

        JsValue StopImmediatePropagation(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            reference.StopImmediately();
            return JsValue.Undefined;
        }

        JsValue PreventDefault(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            reference.Cancel();
            return JsValue.Undefined;
        }

        JsValue InitEvent(JsValue thisObj, JsValue[] arguments)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            var type = TypeConverter.ToString(arguments.At(0));
            var bubbles = TypeConverter.ToBoolean(arguments.At(1));
            var cancelable = TypeConverter.ToBoolean(arguments.At(2));
            reference.Init(type, bubbles, cancelable);
            return JsValue.Undefined;
        }

        JsValue GetOldURL(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.PreviousUrl);
        }


        JsValue GetNewURL(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.CurrentUrl);
        }


        JsValue GetType(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.Type);
        }


        JsValue GetTarget(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.OriginalTarget);
        }


        JsValue GetCurrentTarget(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.CurrentTarget);
        }


        JsValue GetEventPhase(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.Phase);
        }


        JsValue GetBubbles(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.IsBubbling);
        }


        JsValue GetCancelable(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.IsCancelable);
        }


        JsValue GetDefaultPrevented(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.IsDefaultPrevented);
        }


        JsValue GetIsTrusted(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.IsTrusted);
        }

        void SetIsTrusted(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            var value = TypeConverter.ToBoolean(argument);
            reference.IsTrusted = value;
        }

        JsValue GetTimeStamp(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HashChangeEventInstance>(Fail).RefHashChangeEvent;
            return _engine.GetDomNode(reference.Time);
        }


        JsValue ToString(JsValue thisObj, JsValue[] arguments)
        {
            return "[object HashChangeEvent]";
        }

        void Fail(JsValue obsolete)
        {
            throw new JavaScriptException(Engine.TypeError);
        }
    }
}