using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class AccessibilityController : DemoController {
        public override string Name { get { return "Accessibility"; } }

        public ActionResult Index() {
            return RedirectToAction("Compliance");
        }
    }
}
