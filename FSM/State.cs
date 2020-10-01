using System;
using System.Collections.Generic;

namespace FSM
{
    public class State
    {
        private readonly int id;

        private string name;

        private List<Transition> transitionList;

        private List<Action> actionList;

        public State(int id, string name)
        {
            this.id = id;
            this.name = name;

            transitionList = new List<Transition>();
            actionList = new List<Action>();
        }

        public int GetId()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        public bool ContainTransition(Transition transition)
        {
            foreach (Transition t in transitionList)
                if (t.GetId() == transition.GetId())
                    return true;

            return false;
        }

        public void AddTransition(Transition transition)
        {
            if (ContainTransition(transition))
            {
                Console.WriteLine("此转变已存在！");

                return;
            }

            transitionList.Add(transition);
        }

        public bool RemoveTransition(Transition transition)
        {
            if (!ContainTransition(transition))
            {
                Console.WriteLine("此转变不存在！");

                return false;
            }

            return transitionList.Remove(transition);
        }

        public Transition GetEnabledTransition()
        {
            foreach (Transition transition in transitionList)
                if (transition.FulfillAllEvent())
                    return transition;

            return null;
        }

        public void RestoreAllTransitions()
        {
            foreach (Transition transition in transitionList)
                transition.RestoreAllEvents();
        }

        public bool ContainAction(Action action)
        {
            foreach (Action a in actionList)
                if (a.GetId() == action.GetId())
                    return true;

            return false;
        }

        public void AddAction(Action action)
        {
            if (ContainAction(action))
            {
                Console.WriteLine("行动“" + action.GetName() + "”已存在！");

                return;
            }

            actionList.Add(action);
        }

        public bool RemoveAction(Action action)
        {
            if (!ContainAction(action))
            {
                Console.WriteLine("行动“" + action.GetName() + "”不存在！");

                return false;
            }

            return actionList.Remove(action);
        }

        public void DoAction()
        {
            foreach (Action action in actionList)
                action.Act();
        }
    }
}
