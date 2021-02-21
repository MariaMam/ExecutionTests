using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataShapingController : DemoController {
        public ActionResult LargeDatabase() {
            return DemoView("LargeDatabase");
        }
        
        public ActionResult LargeDatabasePartial() {
            return PartialView("LargeDatabasePartial");
        }
    }
}
