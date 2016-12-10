using DaysCalculator.BLL.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysCalculator.BLL.Services.ServiceImpl
{
    public class CustomDateService : ICustomDateService
    {
        #region Fields
        //Cumulative Days by month
        private int[] cumDays = new int[12] { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 };
        //Cumulative Days by month for leap year
        private int[] leapcumDays = new int[12] { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 };
        #endregion

        #region Constructor
        #endregion

        #region Public Methods
        /// <summary>
        /// Take in two date variable and calculte the days diffence between them
        /// </summary>
        /// <param name="date"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public int CalculateDaysDiff(DateTime date, DateTime date2)
        {
            DateTime fromDate;
            DateTime toDate;
            //Always assign the less date to [from], and later date to [to]
            if (date > date2)
            {
                fromDate = date2;
                toDate = date;
            }
            else
            {
                fromDate = date;
                toDate = date2;
            }
            //init params
            int fromYear = fromDate.Year;
            int fromMonth = fromDate.Month;
            int fromDay = fromDate.Day;
            int toYear = toDate.Year;
            int toMonth = toDate.Month;
            int toDay = toDate.Day;
            int totalDays = 0;
            //if both date are on same year
            if (fromYear == toYear)
            {
                if (IsLeapYear(fromYear))
                {
                    return (leapcumDays[toMonth - 1] + toDay) - (leapcumDays[fromMonth - 1] + fromDay);
                }
                else
                {
                    return (cumDays[toMonth - 1] + toDay) - (cumDays[fromMonth - 1] + fromDay);
                }
            }
            else
            {
                if (IsLeapYear(fromYear))
                {
                    totalDays += 366 - (leapcumDays[fromMonth - 1] + fromDay);
                }
                else
                {
                    totalDays += +365 - (cumDays[fromMonth - 1] + fromDay);
                }

                int year = fromYear + 1;
                while (year < toYear)
                {
                    if (IsLeapYear(year))
                        totalDays += 366;
                    else
                        totalDays += 365;
                    year = year + 1;
                }
                if (IsLeapYear(toYear))
                    totalDays += leapcumDays[toMonth - 1] + toDay;
                else
                    totalDays += cumDays[toMonth - 1] + toDay;

                return totalDays;
            }
        }
        #endregion

        #region Private Methods
        private bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            else
                return false;
        }
    #endregion
}
}
