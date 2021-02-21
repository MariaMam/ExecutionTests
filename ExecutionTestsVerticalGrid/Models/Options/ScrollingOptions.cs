using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class ScrollingDemoOptions {
        public ScrollingDemoOptions() {
            HorizontalScrollBarMode = ScrollBarMode.Auto;
            VerticalScrollBarMode = ScrollBarMode.Auto;
        }

        public ScrollBarMode HorizontalScrollBarMode { get; set; }
        public ScrollBarMode VerticalScrollBarMode { get; set; }
    }
}
