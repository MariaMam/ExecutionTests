using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CustomizationController : DemoController {
        public ActionResult Toolbar() {
            ViewBag.IsAllView = true;
            return DemoView("Toolbar", HeadphoneCompareData.GetHeadphones());
        }
        public ActionResult ToolbarPartial(bool? isAllView) {
            ViewBag.IsAllView = isAllView ?? true;
            return PartialView("ToolbarPartial", HeadphoneCompareData.GetHeadphones());
        }
    }
}
