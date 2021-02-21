using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PagingAndScrollingController : DemoController {
        public override string Name { get { return "PagingAndScrolling"; } }

        public ActionResult Index() {
            return RedirectToAction("PagerSettings");
        }
    }
}
