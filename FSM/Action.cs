namespace FSM
{
    public abstract class Action
    {
        private readonly int id;

        private string name;

        public Action(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public abstract void Act();
    }
}
