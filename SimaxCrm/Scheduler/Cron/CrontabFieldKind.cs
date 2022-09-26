using System;

namespace SimaxCrm.Scheduler.Cron
{
    [Serializable]
    public enum CrontabFieldKind
    {
        Minute,
        Hour,
        Day,
        Month,
        DayOfWeek
    }
}