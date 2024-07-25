namespace WorkTimer.Domain.Timers
{
    public class Timer
    {
        public TimeOnly MorningStart { get; set; }
        public TimeOnly MorningEnd { get; set; }
        public TimeOnly AfternoonStart { get; set; }
        public TimeOnly AfternoonEnd { get; private set; }

        public Timer() 
        {
            MorningStart = new TimeOnly(8, 0);
            MorningEnd = new TimeOnly(12, 0);
            AfternoonStart = new TimeOnly(13, 0);
        }

        public void SetAfternoonEnd() 
        {
            var workedMorningHours = MorningEnd - MorningStart;
            var totalHours = new TimeSpan(8, 0, 0);
            var remainingHours = totalHours - workedMorningHours;
            AfternoonEnd = AfternoonStart.Add(remainingHours);
        }
    }
}
