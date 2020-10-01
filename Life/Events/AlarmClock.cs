using FSM;

namespace Life.Events
{
    public class AlarmClock : Event
    {

        private int scheduleTime;

        private int nowTime;

        private int nowTimeRecord;

        public AlarmClock(int id, string name, int scheduleTime, int nowTime) : base(id, name)
        {
            this.scheduleTime = scheduleTime;
            this.nowTime = nowTime;
            nowTimeRecord = nowTime;
        }

        public int GetScheduleTime()
        {
            return scheduleTime;
        }

        public void SetScheduleTime(int time)
        {
            scheduleTime = time;
        }

        public int GetNowTime()
        {
            return nowTime;
        }

        public void SetNowTime(int time)
        {
            nowTime = time;
            nowTimeRecord = time;
        }

        public void AddNowTime()
        {
            nowTime++;
        }

        public override bool Fulfilled()
        {
            return scheduleTime <= nowTime;
        }

        public override void Restore()
        {
            nowTime = nowTimeRecord;
        }
    }
}
