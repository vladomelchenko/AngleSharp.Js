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

    sealed partial class HTMLOutputElementPrototype : HTMLOutputElementInstance
    {
        readonly EngineInstance _engine;

        public HTMLOutputElementPrototype(EngineInstance engine)
            : base(engine)
        {
            _engine = engine;
            FastAddProperty("toString", Engine.AsValue(ToString), true, true, true);
            FastSetProperty("htmlFor", Engine.AsProperty(GetHtmlFor));
            FastSetProperty("defaultValue", Engine.AsProperty(GetDefaultValue, SetDefaultValue));
            FastSetProperty("value", Engine.AsProperty(GetValue, SetValue));
            FastSetProperty("labels", Engine.AsProperty(GetLabels));
            FastSetProperty("type", Engine.AsProperty(GetType));
            FastSetProperty("form", Engine.AsProperty(GetForm));
            FastSetProperty("name", Engine.AsProperty(GetName, SetName));
        }

        public static HTMLOutputElementPrototype CreatePrototypeObject(EngineInstance engine, HTMLOutputElementConstructor constructor)
        {
            var obj = new HTMLOutputElementPrototype(engine)
            {
                Prototype = engine.Constructors.HTMLElement.PrototypeObject,
                Extensible = true,
            };
            obj.FastAddProperty("constructor", constructor, true, false, true);
            return obj;
        }

        JsValue GetHtmlFor(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.HtmlFor);
        }


        JsValue GetDefaultValue(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.DefaultValue);
        }

        void SetDefaultValue(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            var value = TypeConverter.ToString(argument);
            reference.DefaultValue = value;
        }

        JsValue GetValue(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.Value);
        }

        void SetValue(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            var value = TypeConverter.ToString(argument);
            reference.Value = value;
        }

        JsValue GetLabels(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.Labels);
        }


        JsValue GetType(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.Type);
        }


        JsValue GetForm(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.Form);
        }


        JsValue GetName(JsValue thisObj)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            return _engine.GetDomNode(reference.Name);
        }

        void SetName(JsValue thisObj, JsValue argument)
        {
            var reference = thisObj.TryCast<HTMLOutputElementInstance>(Fail).RefHTMLOutputElement;
            var value = TypeConverter.ToString(argument);
            reference.Name = value;
        }

        JsValue ToString(JsValue thisObj, JsValue[] arguments)
        {
            return "[object HTMLOutputElement]";
        }

        void Fail(JsValue obsolete)
        {
            throw new JavaScriptException(Engine.TypeError);
        }
    }
}