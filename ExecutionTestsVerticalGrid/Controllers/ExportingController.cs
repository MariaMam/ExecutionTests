using System.Linq;
using System.Web.Mvc;
using DevExpress.Web.Demos.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ExportingController : DemoController {
        public override string Name { get { return "Exporting"; } }

        public ActionResult Index() {
            return RedirectToAction("Exporting");
        }

        public ActionResult Exporting() {
            return DemoView("Exporting", NorthwindDataProvider.GetProducts());
        }
        public ActionResult ExportingPartial()
        {
            return PartialView("ExportingPartial", NorthwindDataProvider.GetProducts());
        }
    }
}
