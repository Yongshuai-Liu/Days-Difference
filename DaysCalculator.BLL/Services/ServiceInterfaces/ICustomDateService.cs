using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysCalculator.BLL.Services.ServiceInterfaces
{
    public interface ICustomDateService
    {
        /// <summary>
        /// Take in two date variable and calculte the days diffence between them
        /// </summary>
        /// <param name="date"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        int CalculateDaysDiff(DateTime date, DateTime date2);
    }
}
