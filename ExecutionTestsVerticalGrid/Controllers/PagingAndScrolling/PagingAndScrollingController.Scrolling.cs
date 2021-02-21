using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevExpress.Web.Demos {
    public partial class PagingAndScrollingController : DemoController {
        const int pageSizeWithHorizontalScrolling = 10;
        const int pageSizeWithoutHorizontalScrolling = 4;
        public ActionResult Scrolling() {
            return DemoView("Scrolling", GetHeadphones());
        }
        
        [HttpPost]
        public ActionResult Scrolling(ScrollingDemoOptions options) {
            ScrollingDemoHelper.Options.HorizontalScrollBarMode = options.HorizontalScrollBarMode;
            ScrollingDemoHelper.Options.VerticalScrollBarMode = options.VerticalScrollBarMode;
            return DemoView("Scrolling", GetHeadphones());
        }

        public ActionResult ScrollingPartial() {
            return PartialView("ScrollingPartial", GetHeadphones());
        }

        List<Headphone> GetHeadphones() {
            var count = ScrollingDemoHelper.Options.HorizontalScrollBarMode == ScrollBarMode.Hidden ? pageSizeWithoutHorizontalScrolling : pageSizeWithHorizontalScrolling;
            return HeadphonesDataProvider.Headphones.Take(count).ToList();
        }
    }
}
