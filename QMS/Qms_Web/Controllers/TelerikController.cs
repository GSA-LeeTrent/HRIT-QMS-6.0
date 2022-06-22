using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Qms_Web.Models;
using System.Globalization;

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

            //string logSnippet = "[GridController][Orders_Read] =>";
            //Console.WriteLine();
            //foreach (var order in result)
            //{
            //    Console.WriteLine($"{logSnippet} (order.ShipName): '{order.ShipName}'");
            //}
            //Console.WriteLine();

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }


        public ActionResult TotalsByStatus_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTotalsByStatus());
        }

        public ActionResult DaysToResolveTickets_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDaysToResolveTickets());
        }
        public ActionResult DaysToResolveTicketsForMultipleOrgs_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDaysToResolveTicketsForMultipleOrgs());
        }
        public ActionResult DaysToResolveTicketsOnceAtPPRM_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDaysToResolveTicketsOnceAtPPRM());
        }
        public ActionResult TicketsByOrganizationCreatedAt_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTicketsByOrganizationCreatedAt());
        }
        public ActionResult TotalsByOrganization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTotalsByOrganization());
        }
        public ActionResult TicketsByNOA_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTicketsByNOA());
        }
        public ActionResult ErrorTypeCounts_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetErrorTypeCounts());
        }

        public IEnumerable<QMSChart> GetDaysToResolveTickets()
        {
            var daysToResolveTickets = new QMSChart[]
            {
                new QMSChart(1, "0-1", 679),
                new QMSChart(2, "2-5", 441),
                new QMSChart(3, "6-10", 372),
                new QMSChart(4, "11-15", 177),
                new QMSChart(5, "16-20", 90),
                new QMSChart(6, "21-25", 72),
                new QMSChart(7, "31+", 138),
                new QMSChart(8, "60+", 54),
                new QMSChart(9, "90+", 67),
            };

            return daysToResolveTickets;
        }

        public IEnumerable<QMSChart> GetDaysToResolveTicketsForMultipleOrgs()
        {
            var daysToResolveTickets = new QMSChart[]
            {
                new QMSChart(1, "0-1", 679, 441, 372),
                new QMSChart(2, "2-5", 441, 372, 177),
                new QMSChart(3, "6-10", 372, 177, 90),
                new QMSChart(4, "11-15", 177, 90, 72),
                new QMSChart(5, "16-20", 90, 72, 138),
                new QMSChart(6, "21-25", 72, 138, 54),
                new QMSChart(7, "31+", 138, 54, 67),
                new QMSChart(8, "60+", 54, 67, 679),
                new QMSChart(9, "90+", 67, 679, 441),
            };

            return daysToResolveTickets;
        }

        public IEnumerable<QMSChart> GetDaysToResolveTicketsOnceAtPPRM()
        {
            var daysToResolveTicketsOnceAtPPRM = new QMSChart[]
            {
                new QMSChart(1,  "0-1", 960),
                new QMSChart(2,  "2-5", 382),
                new QMSChart(3,  "6-10", 289),
                new QMSChart(4,  "11-15", 145),
                new QMSChart(5,  "16-20", 68),
                new QMSChart(6,  "21-25", 55),
                new QMSChart(7,  "26-30", 48),
                new QMSChart(8,  "31+", 109),
                new QMSChart(9,  "60+", 40),
                new QMSChart(10, "90+", 54),
            };

            return daysToResolveTicketsOnceAtPPRM;
        }


        public IEnumerable<QMSChart> GetTicketsByOrganizationCreatedAt()
        {
            var ticketsByOrganizationCreatedAt = new QMSChart[]
            {
                new QMSChart(1,  "Benefits an...", 239),
                new QMSChart(2,  "CABS HR S...", 217),
                new QMSChart(3,  "Executive R.", 13),
                new QMSChart(4,  "FAS Service...", 852),
                new QMSChart(5,  "National Re...", 18),
                new QMSChart(6,  "Other/Pseu...", 13),
                new QMSChart(7,  "PBS Servic...", 671),
                new QMSChart(8,  "Staff Offices...", 324),
            };

            return ticketsByOrganizationCreatedAt;
        }

        public IEnumerable<QMSChart> GetTotalsByOrganization()
        {
            var totalsByOrganization = new QMSChart[]
            {
                new QMSChart(1, "CABS HR Service Center", 5),
                new QMSChart(2, "Executive Resources Service Center", 1),
                new QMSChart(3, "FAS Service Center", 25),
                new QMSChart(4, "PBS Service Center", 36),
                new QMSChart(5, "Processing Center", 27),
                new QMSChart(6, "Staff Offices Service Center", 25),
            };

            int grandTotal = 0;
            foreach (var tbo in totalsByOrganization)
            {
                grandTotal += tbo.Value;
            }

            foreach (var tbo in totalsByOrganization)
            {
                double percentage = (double)tbo.Value / (double)grandTotal;
                string percentageAsString = percentage.ToString("P1", CultureInfo.CreateSpecificCulture("en-US"));
                tbo.Key = $"{tbo.Key} ({percentageAsString})";
            }

            return totalsByOrganization;
        }

        public IEnumerable<QMSChart> GetTotalsByStatus()
        {
            var totalsByStatus = new QMSChart[]
            {
                new QMSChart(1, "Assigned", 79),
                new QMSChart(2, "Closed - Action Completed", 1916),
                new QMSChart(3, "Closed - No Action Required", 234),
                new QMSChart(4, "Draft", 10),
                new QMSChart(5, "Pending Review", 11),
                new QMSChart(6, "Returned", 92),
                new QMSChart(7, "Unassigned", 5),
            };

            int grandTotal = 0;
            foreach (var tbs in totalsByStatus)
            {
                grandTotal += tbs.Value;
            }

            foreach (var tbs in totalsByStatus)
            {
                double percentage = (double)tbs.Value / (double)grandTotal;
                string percentageAsString = percentage.ToString("P1", CultureInfo.CreateSpecificCulture("en-US"));
                tbs.Key = $"{tbs.Key} ({percentageAsString})";
            }

            return totalsByStatus;
        }

        public IEnumerable<QMSChart> GetTicketsByNOA()
        {
            var ticketsByNOA = new QMSChart[]
            {
                new QMSChart(1,  "0", 1),
                new QMSChart(2,  "100", 52),
                new QMSChart(3,  "101", 196),
                new QMSChart(4,  "108", 21),
                new QMSChart(5,  "115", 19),
                new QMSChart(6,  "122", 1),
                new QMSChart(7,  "130", 173),
                new QMSChart(8,  "140", 27),
                new QMSChart(9,  "141", 6),
                new QMSChart(10,  "142", 1),
                new QMSChart(11,  "143", 1),
                new QMSChart(12,  "170", 188),
                new QMSChart(13,  "171", 72),
                new QMSChart(14,  "190", 17),
                new QMSChart(15,  "292", 5),
                new QMSChart(16,  "302", 1),
                new QMSChart(17,  "304", 1),
                new QMSChart(18,  "317", 7),
                new QMSChart(19,  "330", 1),
                new QMSChart(20,  "352", 7),
                new QMSChart(21,  "355", 3),
                new QMSChart(22,  "385", 4),
                new QMSChart(23,  "430", 1),
                new QMSChart(24,  "460", 9),
                new QMSChart(25,  "473", 12),
                new QMSChart(26,  "500", 37),
                new QMSChart(27,  "501", 62),
                new QMSChart(28,  "508", 15),
                new QMSChart(29,  "515", 2),
                new QMSChart(30,  "522", 2),
                new QMSChart(31,  "540", 1),
                new QMSChart(32,  "542", 1),
                new QMSChart(33,  "546", 1),
                new QMSChart(34,  "570", 21),
                new QMSChart(35,  "571", 17),
                new QMSChart(36,  "590", 4),
                new QMSChart(37,  "702", 273),
                new QMSChart(38,  "703", 63),
                new QMSChart(39,  "713", 19),
                new QMSChart(40,  "721", 204),
                new QMSChart(41,  "730", 6),
                new QMSChart(42,  "732", 3),
                new QMSChart(43,  "740", 1),
                new QMSChart(44,  "741", 1),
                new QMSChart(45,  "760", 20),
                new QMSChart(46,  "762", 2),
                new QMSChart(47,  "769", 2),
                new QMSChart(48,  "780", 5),
                new QMSChart(49,  "781", 4),
                new QMSChart(50,  "782", 3),
                new QMSChart(51,  "790", 23),
                new QMSChart(52,  "792", 34),
                new QMSChart(53,  "800", 24),
                new QMSChart(54,  "803", 19),
                new QMSChart(55,  "840", 12),
                new QMSChart(56, "841", 1),
                new QMSChart(57, "846", 6),
                new QMSChart(58, "849", 28),
                new QMSChart(59, "800", 21),
                new QMSChart(60, "881", 40),
                new QMSChart(61, "882", 44),
                new QMSChart(62, "883", 10),
                new QMSChart(63, "899", 2),
                new QMSChart(64, "906", 12),
                new QMSChart(65, "930", 82),
                new QMSChart(70, "931", 22),
                new QMSChart(71, "932", 42),
                new QMSChart(72, "981", 33),
                new QMSChart(73, "982", 6),
                new QMSChart(74, "991", 3),
                new QMSChart(75, "995", 22),
                new QMSChart(76, "999", 121),
            };

            return ticketsByNOA;
        }

        public IEnumerable<QMSChart> GetErrorTypeCounts()
        {
            var ticketsByNOA = new QMSChart[]
            {
                new QMSChart(1,  "Appointment Type", 91),
                new QMSChart(2,  "Bargaining Unit Status", 84),
                new QMSChart(3,  "Date of Birth", 6),
                new QMSChart(4,  "Department/Organization", 189),
                new QMSChart(5,  "Double Encumbered", 3),
                new QMSChart(6,  "Effective Date", 104),
                new QMSChart(7,  "FEGLI", 50),
                new QMSChart(8,  "FLSA Category", 21),
                new QMSChart(9,  "Gender", 8),
                new QMSChart(39,  "Grade", 33),
                new QMSChart(10,  "Hours", 16),
                new QMSChart(11,  "Legal Authority Code", 136),
                new QMSChart(12,  "Location Code/Duty Station", 283),
                new QMSChart(13,  "Name", 24),
                new QMSChart(14,  "Nature of Action", 180),
                new QMSChart(15,  "Not to Exceed Date", 86),
                new QMSChart(16,  "Occupational Series", 25),
                new QMSChart(17,  "Pay Plan", 9),
                new QMSChart(18,  "Pay Rate Determinant", 8),
                new QMSChart(19,  "Personnel Office ID", 17),
                new QMSChart(20,  "Place of Birth", 1),
                new QMSChart(21,  "Position Description", 144),
                new QMSChart(22,  "Position Number", 152),
                new QMSChart(23,  "Position Occupied", 70),
                new QMSChart(24,  "Position Title", 75),
                new QMSChart(25,  "Probationary/Trial Period Date", 124),
                new QMSChart(26,  "Remarks", 140),
                new QMSChart(27,  "Reports to", 195),
                new QMSChart(28,  "Retirement Plan", 105),
                new QMSChart(29,  "SSN", 8),
                new QMSChart(30,  "Salary Admin Plan", 22),
                new QMSChart(31,  "Security Clearance", 3),
                new QMSChart(32,  "Service Computation Date", 122),
                new QMSChart(33,  "Step", 127),
                new QMSChart(34,  "Supervisor Level", 22),
                new QMSChart(35,  "Tenure", 127),
                new QMSChart(36,  "Veteran Preference", 41),
                new QMSChart(37,  "WGI Date", 139),
                new QMSChart(38,  "Work Schedule", 13),
             };

            return ticketsByNOA;
        }

    }

    public class TelerikViewModel
    {
        public int OrderID
        {
            get;
            set;
        }

        public decimal? Freight
        {
            get;
            set;
        }

        [System.ComponentModel.DataAnnotations.Required]
        public DateTime? OrderDate
        {
            get;
            set;
        }

        public string ShipCity
        {
            get;
            set;
        }

        public string ShipName
        {
            get;
            set;
        }
    }

    public class QMSChart
    {
        public QMSChart(int id, string key, int value)
        {
            Id = id;
            Key = key;
            Value = value;
        }

        public QMSChart(int id, string key, int val1, int val2, int val3)
        {
            Id = id;
            Key = key;
            Value = val1;
            ValueTwo = val2;
            ValueThree = val3;
        }

        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public int Value { get; set; }
        public int ValueTwo { get; set; }
        public int ValueThree { get; set; }
    }
}
