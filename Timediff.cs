using System;
namespace test
{
    public class Timediff
    {
        	


        const int second = 1;
        const int minute = 60 * second;
        const int hr = 60 * minute;
        const int day = 24 * hr;
        const int month = 30 * day;

        public string TimeDiff(DateTime givenDate){
              var ts = givenDate- DateTime.Now;
              double diff = ts.TotalSeconds;

                if (diff < 1)
                return ts.Seconds == 1 ? "one second left" : ts.Seconds + " seconds left";

                if (diff < 60)
                return "one minute left";

                if (diff < 60*45)
                return ts.Minutes + " minutes left";

                if (diff < 3600)
                return "an hour left";

                if (diff < 24 * 3600)
                return ts.Hours + " hours left";

                if (diff < 48 * 3600)
                return "2 days left";

                if (diff < 30 * day)
                return ts.Days + " days left";

                if (diff < 12 * month)
                {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month left" : months + " months left";
                }
                else
                {
                int years = (int)ts.TotalDays/365;
                return years <= 1 ? "one year left" : years + " years left";
                }
        }
    }
}