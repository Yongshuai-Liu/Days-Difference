using DaysCalculator.BLL.Services.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaysCalculator.Controllers
{
    public class DaysCalculateController : Controller
    {
        #region Fields
        private readonly ICustomDateService _customDateService;
        #endregion

        #region Constructor
        public DaysCalculateController(ICustomDateService customDateService)
        {
            _customDateService = customDateService;
        }
        #endregion

        #region Public Methods
        // GET: DaysCalculate
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Calculate(string fromDate, string toDate)
        {
            DateTime from;
            DateTime to;
            int result;
            try
            {
                DateTime.TryParse(fromDate, out from);
                DateTime.TryParse(toDate, out to);
                result = _customDateService.CalculateDaysDiff(from, to);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Bad Request", JsonRequestBehavior.AllowGet);
            }          
        }
        #endregion
    }
}