namespace AngleSharp.Scripting.JavaScript
{
    using AngleSharp.Dom.Events;
    using Jint;
    using Jint.Runtime;
    using Jint.Native;
    using Jint.Native.Object;
    using System;

    partial class PageTransitionEventInstance : EventInstance
    {
        readonly EngineInstance _engine;

        public PageTransitionEventInstance(EngineInstance engine)
            : base(engine)
        {
            _engine = engine;
        }

        public static PageTransitionEventInstance CreatePageTransitionEventObject(EngineInstance engine)
        {
            var obj = new PageTransitionEventInstance(engine);
            obj.Extensible = true;
            obj.Prototype = engine.Jint.Object.PrototypeObject;            
            return obj;
        }

        public override String Class
        {
            get { return "PageTransitionEvent"; }
        }

        public PageTransitionEvent RefPageTransitionEvent
        {
            get;
            set;
        }
    }
}