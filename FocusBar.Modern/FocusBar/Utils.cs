using System;

namespace FocusBar
{
    public static class Utils
    {
        public static string FormatTimeElapsed(uint timeElapsed)
        {
            uint secs, mins, hours;
            double total;
            string timeString = "";

            total = timeElapsed;

            hours = (uint)total / 3600;
            total = total - (hours * 3600);

            mins = (uint)total / 60;
            total = total - (mins * 60);

            secs = (uint)total;

            timeString += (hours < 10) ? "0" : "";
            timeString += hours.ToString();
            timeString += ":";

            timeString += (mins < 10) ? "0" : "";
            timeString += mins.ToString();
            timeString += ":";

            timeString += (secs < 10) ? "0" : "";
            timeString += secs.ToString();

            return timeString;
        }
    }
}