using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class FilteringAndSortingController: DemoController {
        public override string Name { get { return "FilteringAndSorting"; } }
        
        public ActionResult Index() {
            return RedirectToAction("SearchPanel");
        }
    }
}
