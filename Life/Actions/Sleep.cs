using FSM;
using Life.Events;
using System;

namespace Life.Actions
{
    public class Sleep : FSM.Action
    {
        private AlarmClock clock;

        public Sleep(int id, string name, AlarmClock clock) : base(id, name)
        {
            this.clock = clock;
        }

        public override void Act()
        {
            Console.WriteLine("正在睡觉。");

            clock.AddNowTime();
        }
    }
}
