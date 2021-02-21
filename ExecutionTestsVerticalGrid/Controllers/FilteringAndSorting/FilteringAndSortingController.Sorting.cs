using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class FilteringAndSortingController: DemoController {
        public ActionResult Sorting() {
            return DemoView("Sorting", HeadphonesDataProvider.Headphones);
        }
        public ActionResult SortingPartial() {
            return PartialView("SortingPartial", HeadphonesDataProvider.Headphones);
        }
    }
}
