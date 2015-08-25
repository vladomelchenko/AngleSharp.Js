namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Html;
    using Jint;
    using Jint.Runtime;
    using Jint.Native;
    using Jint.Native.Object;
    using System;

    partial class HTMLTableElementInstance : HTMLElementInstance
    {
        readonly EngineInstance _engine;

        public HTMLTableElementInstance(EngineInstance engine)
            : base(engine)
        {
            _engine = engine;
        }

        public static HTMLTableElementInstance CreateHTMLTableElementObject(EngineInstance engine)
        {
            var obj = new HTMLTableElementInstance(engine);
            obj.Extensible = true;
            obj.Prototype = engine.Jint.Object.PrototypeObject;            
            return obj;
        }

        public override String Class
        {
            get { return "HTMLTableElement"; }
        }

        public IHtmlTableElement RefHTMLTableElement
        {
            get;
            set;
        }
    }
}