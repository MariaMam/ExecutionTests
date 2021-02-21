using System.Web.Mvc;
using DevExpress.Web.Demos.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PagingAndScrollingController : DemoController {
        public ActionResult PagerSettings() {
            var fullInvoices = NorthwindDataProvider.GetFullInvoices();
            return DemoView("PagerSettings", fullInvoices);
        }
        [HttpPost]
        public ActionResult PagerSettings(PagerDemoOptions options) {
            PagerDemoHelper.Options = options;
            return DemoView("PagerSettings", NorthwindDataProvider.GetFullInvoices());
        }
        public ActionResult PagerSettingsPartial() {
            return PartialView("PagerSettingsPartial", NorthwindDataProvider.GetFullInvoices());
        }
    }
}
