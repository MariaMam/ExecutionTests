using System.Web.Mvc;
using System.Threading;

namespace DevExpress.Web.Demos {
    public partial class GridRowsController : DemoController {
        public ActionResult Categories() {
            return DemoView("Categories", GetHeadphones());
        }
        [HttpPost]
        public ActionResult Categories(CategoriesDemoOptions options) {
            var previousEnableCallbackMode = CategoriesDemoHelper.Options.EnableCallbackMode;
            if(previousEnableCallbackMode != options.EnableCallbackMode && options.EnableCallbackMode)
                ViewBag.NeedCollapseCategories = true;

            CategoriesDemoHelper.Options = options;
            return DemoView("Categories", GetHeadphones());
        }
        public ActionResult CategoriesPartial() {
            Thread.Sleep(1000);
            return PartialView("CategoriesPartial", GetHeadphones());
        }
    }
}
