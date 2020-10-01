using Life.Events;
using System;

namespace Life.Actions
{
    public class TakeClass : FSM.Action
    {
        private ClassBell bell;

        private ClassNotFinished classNotFinished;

        public TakeClass(int id, string name, ClassBell bell, ClassNotFinished classNotFinished) : base(id, name)
        {
            this.bell = bell;
            this.classNotFinished = classNotFinished;
        }

        public override void Act()
        {
            Console.WriteLine("正在上课。");

            bell.SetFinished(true);
            classNotFinished.SetNotFinished(false);
        }
    }
}
