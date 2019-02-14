using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            //note: 24:00:00 cannot be parsed to timespan because the datetime class max time is 23:59:59
            //convert time string to individual parts instead
            string[] timeParts = aTime.Split(':');
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);
            int seconds = int.Parse(timeParts[2]);

            //calculate each row independently and append to string
            StringBuilder berlinClockBuilder = new StringBuilder();

            berlinClockBuilder.CalculateSecondsLamp(seconds);
            berlinClockBuilder.CalculateFirstHourRowLamps(hours);
            berlinClockBuilder.CalculateSecondHourRowLamps(hours);
            berlinClockBuilder.CalculateFirstMinuteRowLamps(minutes);
            berlinClockBuilder.CalculateSecondMinuteRowLamps(minutes);

            return berlinClockBuilder.ToString();
        }
    }   
}
