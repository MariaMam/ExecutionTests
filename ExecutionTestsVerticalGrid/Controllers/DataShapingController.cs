using System.Collections;
using System.Linq;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataShapingController : DemoController {

        public override string Name { get { return "DataShaping"; } }

        static DataShapingController() {
            EmailDataGenerator.Register();
        }

        public ActionResult Index() {
            return RedirectToAction("LargeDatabase");
        }
    }
}
