using Life.Events;
using System;

namespace Life.Actions
{
    public class PlayGame : FSM.Action
    {
        private GameFinished gameFinished;

        public PlayGame(int id, string name, GameFinished gameFinished) : base(id, name)
        {
            this.gameFinished = gameFinished;
        }

        public override void Act()
        {
            Console.WriteLine("正在打游戏。");

            gameFinished.SetFinished(true);
        }
    }
}
