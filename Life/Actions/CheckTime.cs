using Life.Events;
using System;

namespace Life.Actions
{
    public class CheckTime : FSM.Action
    {
        private StillEarly early;

        private TooLate late;

        private Random random;

        public CheckTime(int id, string name, StillEarly early, TooLate late) : base(id, name)
        {
            this.early = early;
            this.late = late;

            random = new Random();
        }

        public override void Act()
        {
            Console.Write("看看时间，");

            if (random.Next(2) == 0)
            {
                early.SetEarly(true);
                late.SetLate(false);

                Console.WriteLine("时间还早。");
            }
            else
            {
                early.SetEarly(false);
                late.SetLate(true);

                Console.WriteLine("时间不早了。");
            }
        }
    }
}
