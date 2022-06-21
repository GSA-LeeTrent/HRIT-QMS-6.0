using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Qms_Web.Models;

namespace Qms_Web.Controllers
{
    public class TelerikController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Grid()
        {
            return View();
        }

        public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            var result = Enumerable.Range(0, 50).Select(i => new TelerikViewModel
            {
                OrderID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
                ShipName = "ShipName " + i,
                ShipCity = "ShipCity " + i
            });

            string logSnippet = "[GridController][Orders_Read] =>";
            Console.WriteLine();
            foreach (var order in result)
            {
                Console.WriteLine($"{logSnippet} (order.ShipName): '{order.ShipName}'");
            }
            Console.WriteLine();

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
    }
}
