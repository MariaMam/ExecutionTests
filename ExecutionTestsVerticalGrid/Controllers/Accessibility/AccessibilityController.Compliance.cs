using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class AccessibilityController : DemoController {
        public ActionResult Compliance() {
            return DemoView("Compliance", HeadphonesDataProvider.Headphones);
        }

        public ActionResult CompliancePartial() {
            return PartialView("CompliancePartial", HeadphonesDataProvider.Headphones);
        }
    }
}
