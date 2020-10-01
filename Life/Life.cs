using FSM;
using Life.Actions;
using Life.Events;
using System;

namespace Life
{
    public class Life
    {
        public static void Main()
        {
            int id = 1;

            State s1 = new State(id++, "睡觉中");
            State s2 = new State(id++, "吃饭中");
            State s3 = new State(id++, "上课中");
            State s4 = new State(id++, "看时间中");
            State s5 = new State(id++, "打游戏中");

            Transition t1 = new Transition(id++, s1, s2);
            Transition t2 = new Transition(id++, s2, s3);
            Transition t3 = new Transition(id++, s3, s2);
            Transition t4 = new Transition(id++, s2, s4);
            Transition t5 = new Transition(id++, s4, s5);
            Transition t6 = new Transition(id++, s4, s1);
            Transition t7 = new Transition(id++, s5, s1);

            AlarmClock clock = new AlarmClock(id++, "闹钟响", 7, 6);
            Eaten eaten1 = new Eaten(id++, "吃完饭");
            Eaten eaten2 = new Eaten(id++, "吃完饭");
            ClassNotFinished classNotFinished = new ClassNotFinished(id++, "还有课要上");
            ClassBell bell = new ClassBell(id++, "下课铃响");
            StillEarly early = new StillEarly(id++, "时间还早");
            TooLate late = new TooLate(id++, "时间不早了");
            GameFinished gameFinished = new GameFinished(id++, "打完游戏");

            t1.AddEvent(clock);
            t2.AddEvent(eaten1);
            t2.AddEvent(classNotFinished);
            t3.AddEvent(bell);
            t4.AddEvent(eaten2);
            t5.AddEvent(early);
            t6.AddEvent(late);
            t7.AddEvent(gameFinished);

            Sleep sleep = new Sleep(id++, "睡觉", clock);
            Eat eat = new Eat(id++, "吃饭", eaten1, eaten2);
            TakeClass takeClass = new TakeClass(id++, "上课", bell, classNotFinished);
            CheckTime checkTime = new CheckTime(id++, "看时间", early, late);
            PlayGame playGame = new PlayGame(id++, "打游戏", gameFinished);

            s1.AddTransition(t1);
            s2.AddTransition(t2);
            s2.AddTransition(t4);
            s3.AddTransition(t3);
            s4.AddTransition(t5);
            s4.AddTransition(t6);
            s5.AddTransition(t7);

            s1.AddAction(sleep);
            s2.AddAction(eat);
            s3.AddAction(takeClass);
            s4.AddAction(checkTime);
            s5.AddAction(playGame);

            FSM.FSM fsm = new FSM.FSM();
            fsm.AddState(s1);
            fsm.AddState(s2);
            fsm.AddState(s3);
            fsm.AddState(s4);
            fsm.AddState(s5);
            fsm.SetStartState(s1);
            fsm.SetCurrentState(s1);

            ConsoleKeyInfo cki;

            Console.WriteLine("生活行为状态机, 按 N 键进行下一步，按 E 键退出程序。");
            while(true)
            {
                Console.WriteLine("请输入：");

                cki = Console.ReadKey();

                Console.WriteLine();

                if (cki.Key == ConsoleKey.N)
                {
                    Console.WriteLine("当前状态：" + fsm.GetCurrentState().GetName());

                    fsm.CheckAndChangeState();
                }
                else if (cki.Key == ConsoleKey.E)
                    break;
                else
                    Console.WriteLine("输入无效，请重新输入：");
            }
        }
    }
}
