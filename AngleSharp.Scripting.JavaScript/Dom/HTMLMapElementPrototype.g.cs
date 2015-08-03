namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Html;
    using Jint;
    using Jint.Native;
    using Jint.Native.Object;
    using Jint.Runtime;
    using Jint.Runtime.Descriptors;
    using Jint.Runtime.Interop;
    using System;

    sealed partial class HTMLMapElementPrototype : HTMLMapElementInstance
    {
        public HTMLMapElementPrototype(Engine engine)
            : base(engine)
        {
            FastAddProperty("toString", Engine.AsValue(ToString), true, true, true);
            FastSetProperty("name", Engine.AsProperty(GetName, SetName));
            FastSetProperty("areas", Engine.AsProperty(GetAreas));
            FastSetProperty("images", Engine.AsProperty(GetImages));
        }

        public static HTMLMapElementPrototype CreatePrototypeObject(EngineInstance engine, HTMLMapElementConstructor constructor)
        {
            var obj = new HTMLMapElementPrototype(engine.Jint)
            {
                Prototype = engine.Constructors.HTMLElement.PrototypeObject,
                Extensible = true,
            };
            obj.FastAddProperty("constructor", constructor, true, false, true);
            return obj;
        }

        JsValue GetName(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLMapElementInstance>(Fail).RefHTMLMapElement;
            return Engine.Select(reference.Name);
        }

        void SetName(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLMapElementInstance>(Fail).RefHTMLMapElement;
            var value = TypeConverter.ToString(argument);
            reference.Name = value;
        }

        JsValue GetAreas(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLMapElementInstance>(Fail).RefHTMLMapElement;
            return Engine.Select(reference.Areas);
        }


        JsValue GetImages(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLMapElementInstance>(Fail).RefHTMLMapElement;
            return Engine.Select(reference.Images);
        }


        JsValue ToString(JsValue thisObj, JsValue[] arguments)
        {
            return "[object HTMLMapElement]";
        }

        void Fail(JsValue obsolete)
        {
            throw new JavaScriptException(Engine.TypeError);
        }
    }
}