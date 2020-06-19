using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcUDE.Services;

namespace mvcUDE.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            this.salesRecordService = salesRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            var result = await salesRecordService.FindByDateAsync(minDate, maxDate);
            return View();
        }
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}