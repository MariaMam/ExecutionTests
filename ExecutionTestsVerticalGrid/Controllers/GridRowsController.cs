using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.Web.Demos {
    public partial class GridRowsController : DemoController {
        public override string Name { get { return "GridRows"; } }

        public ActionResult Index() {
            return RedirectToAction("Categories");
        }

        List<Headphone> GetHeadphones() {
            return HeadphonesDataProvider.Headphones.Take(4).ToList();
        }
    }
}
