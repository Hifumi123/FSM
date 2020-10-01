using FSM;

namespace Life.Events
{
    public class Eaten : Event
    {
        private bool finished;

        public Eaten(int id, string name) : base(id, name)
        {
            finished = false;
        }

        public bool GetFinished()
        {
            return finished;
        }

        public void SetFinished(bool finished)
        {
            this.finished = finished;
        }

        public override bool Fulfilled()
        {
            return finished;
        }

        public override void Restore()
        {
            finished = false;
        }
    }
}
