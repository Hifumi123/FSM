using FSM;

namespace Life.Events
{
    public class StillEarly : Event
    {
        private bool early;

        public StillEarly(int id, string name) : base(id, name)
        {
            early = false;
        }

        public bool GetEarly()
        {
            return early;
        }

        public void SetEarly(bool early)
        {
            this.early = early;
        }

        public override bool Fulfilled()
        {
            return early;
        }

        public override void Restore()
        {
            early = false;
        }
    }
}
