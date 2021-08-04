using System;

namespace Prompton.Models
{
    public class Timer : Step
    {
        public bool Countdown { get; set; }
        public TimeSpan Limit { get; set; }
    }
}
