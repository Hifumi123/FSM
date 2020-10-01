using FSM;
using Life.Events;
using System;

namespace Life.Actions
{
    public class Eat : FSM.Action
    {
        private Eaten eaten1;

        private Eaten eaten2;

        public Eat(int id, string name, Eaten eaten1, Eaten eaten2) : base(id, name)
        {
            this.eaten1 = eaten1;
            this.eaten2 = eaten2;
        }

        public override void Act()
        {
            Console.WriteLine("正在吃饭。");

            if (!eaten1.GetFinished())
                eaten1.SetFinished(true);
            else
                eaten2.SetFinished(true);
        }
    }
}
