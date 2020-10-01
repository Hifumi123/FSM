using System;
using System.Collections.Generic;

namespace FSM
{
    public class Transition
    {
        private readonly int id;

        private State start;

        private State end;

        private List<Event> eventList;

        public Transition(int id, State start, State end)
        {
            this.id = id;
            this.start = start;
            this.end = end;

            eventList = new List<Event>();
        }

        public int GetId()
        {
            return id;
        }

        public State GetStart()
        {
            return start;
        }

        public State GetEnd()
        {
            return end;
        }

        public bool ContainEvent(Event e)
        {
            foreach (Event eve in eventList)
                if (eve.GetId() == e.GetId())
                    return true;

            return false;
        }

        public void AddEvent(Event e)
        {
            if (ContainEvent(e))
            {
                Console.WriteLine("事件“" + e.GetName() + "”已存在！");

                return;
            }

            eventList.Add(e);
        }

        public bool RemoveEvent(Event e)
        {
            if (!ContainEvent(e))
            {
                Console.WriteLine("事件“" + e.GetName() + "”不存在！");

                return false;
            }

            return eventList.Remove(e);
        }

        public bool FulfillAllEvent()
        {
            foreach (Event e in eventList)
                if (!e.Fulfilled())
                    return false;

            return true;
        }

        public void RestoreAllEvents()
        {
            foreach (Event e in eventList)
                e.Restore();
        }
    }
}
