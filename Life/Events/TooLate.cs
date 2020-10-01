using FSM;

namespace Life.Events
{
    public class TooLate : Event
    {
        public bool late;

        public TooLate(int id, string name) : base(id, name)
        {
            late = false;
        }

        public bool GetLate()
        {
            return late;
        }

        public void SetLate(bool late)
        {
            this.late = late;
        }

        public override bool Fulfilled()
        {
            return late;
        }

        public override void Restore()
        {
            late = false;
        }
    }
}
