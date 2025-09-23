using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusBarWin
{
    class Util
    {
        public static string formatTimeElapsed(uint timeElapsed)
        {
            uint secs, mins, hours;
            double total;
            string timeString = "";

            total = timeElapsed;

            hours = (uint) total / 3600;
            total = total - (hours * 3600);

            mins = (uint) total / 60;
            total = total - (mins * 60);

            secs = (uint) total;

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
