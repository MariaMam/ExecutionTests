using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class AppearanceController: DemoController {
        public override string Name { get { return "Appearance"; } }

        public ActionResult Index() {
            return RedirectToAction("ConditionalFormatting");
        }

        public ActionResult ConditionalFormatting() {
            return DemoView("ConditionalFormatting", HomesDataProvider.Homes);
        }

        public ActionResult ConditionalFormattingPartial() {
            return PartialView("ConditionalFormattingPartial", HomesDataProvider.Homes);
        }
    }
}
