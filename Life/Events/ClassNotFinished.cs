using FSM;

namespace Life.Events
{
    public class ClassNotFinished : Event
    {
        private bool notFinished;

        public ClassNotFinished(int id, string name) : base(id, name)
        {
            notFinished = true;
        }

        public bool GetNotFinished()
        {
            return notFinished;
        }

        public void SetNotFinished(bool notFinished)
        {
            this.notFinished = notFinished;
        }

        public override bool Fulfilled()
        {
            return notFinished;
        }

        public override void Restore()
        {
            notFinished = true;
        }
    }
}
