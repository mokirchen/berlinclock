using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public static class TimeConverterExtensions
    {
        public static void CalculateSecondsLamp(this StringBuilder sb, int seconds) => sb.Append(seconds % 2 == 0 ? "Y" : "O");

        public static void CalculateFirstHourRowLamps(this StringBuilder sb, int hours)
        {
            sb.Append("\n");
            int timesDivisibleByFive = hours / 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= timesDivisibleByFive)
                {
                    sb.Append("R");
                }
                else
                {
                    sb.Append("O");
                }
            }
        }

        public static void CalculateSecondHourRowLamps(this StringBuilder sb, int hours)
        {
            sb.Append("\n");
            int divisionRemainder = hours % 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= divisionRemainder)
                {
                    sb.Append("R");
                }
                else
                {
                    sb.Append("O");
                }
            }
        }

        public static void CalculateFirstMinuteRowLamps(this StringBuilder sb, int minutes)
        {
            sb.Append("\n");
            int timesDivisibleByFive = minutes / 5;
            for (int i = 1; i <= 11; i++)
            {
                if (i <= timesDivisibleByFive)
                {
                    //check if quarter lamp is reached
                    if (i % 3 == 0)
                    {
                        sb.Append("R");
                    }
                    else
                    {
                        sb.Append("Y");
                    }
                }
                else
                {
                    sb.Append("O");
                }
            }
        }

        public static void CalculateSecondMinuteRowLamps(this StringBuilder sb, int minutes)
        {
            sb.Append("\n");
            int divisionRemainder = minutes % 5;
            for (int i = 1; i <= 4; i++)
            {
                if (i <= divisionRemainder)
                {
                    sb.Append("Y");
                }
                else
                {
                    sb.Append("O");
                }
            }
        }
    }
}
