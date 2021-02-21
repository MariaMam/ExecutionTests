using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class OverviewController : DemoController {
        public override string Name { get { return ""; } }

        public ActionResult Index() {
            return DemoView("Overview", GetEmployees());
        }
        public ActionResult OverviewPartial() {
            return PartialView("OverviewPartial", GetEmployees());
        }
        public static IEnumerable GetEmployees() {
            NorthwindContext DB = new NorthwindContext();
            return DB.Employees.Take(2).ToList();
        }
    }
}
