using System;
using System.Collections.Generic;

namespace FSM
{
    public class FSM
    {
        private State startState;

        private State currentState;

        private readonly List<State> stateList;

        public FSM()
        {
            stateList = new List<State>();
        }

        public State GetStartState()
        {
            return startState;
        }

        public void SetStartState(State state)
        {
            if (!ContainState(state))
            {
                Console.WriteLine("状态“" + state.GetName() + "”不存在！");

                return;
            }

            startState = state;
        }

        public State GetCurrentState()
        {
            return currentState;
        }

        public void SetCurrentState(State state)
        {
            if (!ContainState(state))
            {
                Console.WriteLine("状态“" + state.GetName() + "”不存在！");

                return;
            }

            currentState = state;
        }

        public bool ContainState(State state)
        {
            foreach (State s in stateList)
                if (s.GetId() == state.GetId())
                    return true;

            return false;
        }

        public void AddState(State state)
        {
            if (ContainState(state))
            {
                Console.WriteLine("状态“" + state.GetName() + "”已存在！");

                return;
            }

            stateList.Add(state);
        }

        public bool RemoveState(State state)
        {
            if (!ContainState(state))
            {
                Console.WriteLine("状态“" + state.GetName() + "”不存在！");

                return false;
            }

            if (currentState.GetId() == state.GetId())
            {
                Console.WriteLine("状态“" + state.GetName() + "”是当前状态，无法删除！");

                return false;
            }

            return stateList.Remove(state);
        }

        public void RestoreAllStates()
        {
            foreach (State state in stateList)
                state.RestoreAllTransitions();
        }

        public void CheckAndChangeState()
        {
            Transition transition = currentState.GetEnabledTransition();

            if (transition != null)
            {
                Console.Write("由“" + currentState.GetName() + "”状态");

                currentState = transition.GetEnd();

                Console.WriteLine("到“" + currentState.GetName() + "”状态。");

                if (currentState.GetId() == startState.GetId())
                    RestoreAllStates();
            }
            else
                currentState.DoAction();
        }
    }
}
