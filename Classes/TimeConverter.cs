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
            //note: 24:00:00 cannot be parsed to timespan because the max hour in gregorian calendar is 23
            //convert time string to individual parts instead
            string[] timeParts = aTime.Split(':');
            int hours = int.Parse(timeParts[0]);
            int minutes = int.Parse(timeParts[1]);
            int seconds = int.Parse(timeParts[2]);
        
            //calculate each row independently and append to string
            StringBuilder berlinClockBuilder = new StringBuilder();
            berlinClockBuilder.Append(CalculateSecondsLamp(seconds));
            berlinClockBuilder.Append("\n" + CalculateFirstHourRowLamps(hours));
            berlinClockBuilder.Append("\n" + CalculateSecondHourRowLamps(hours));
            berlinClockBuilder.Append("\n" + CalculateFirstMinuteRowLamps(minutes));
            berlinClockBuilder.Append("\n" + CalculateSecondMinuteRowLamps(minutes));

            return berlinClockBuilder.ToString();
        }

        private string CalculateSecondsLamp(int seconds)
        {
            return seconds % 2 == 0 ? "Y" : "O";
        }

        private string CalculateFirstHourRowLamps(int hours)
        {
            string row = string.Empty;
            int timesDivisibleByFive = hours / 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= timesDivisibleByFive)
                {
                    row += "R";
                }
                else
                {
                    row += "O";
                }
            }
            return row;
        }

        private string CalculateSecondHourRowLamps(int hours)
        {
            int divisionRemainder = hours % 5;
            string row = string.Empty;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= divisionRemainder)
                {
                    row += "R";
                }
                else
                {
                    row += "O";
                }
            }
            return row;
        }

        private string CalculateFirstMinuteRowLamps(int minutes)
        {
            string row = string.Empty;
            int timesDivisibleByFive = minutes / 5;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= timesDivisibleByFive)
                {
                    //check if quarter lamp is reached
                    if (i % 3 == 0)
                    {
                        row += "R";
                    }
                    else
                    {
                        row += "Y";
                    }
                }
                else
                {
                    row += "O";
                }
            }
            return row;
        }

        private string CalculateSecondMinuteRowLamps(int minutes)
        {
            string row = string.Empty;
            int divisionRemainder = minutes % 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= divisionRemainder)
                {
                    row += "Y";
                }
                else
                {
                    row += "O";
                }
            }
            return row;
        }
    }
}
