using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class PagerDemoOptions {
        public PagerDemoOptions() {
            Position = PagerPosition.TopAndBottom;
            PageSizeItemPosition = PagerPageSizePosition.Right;
            ShowPageSizeItem = true;
            ShowDisabledButtons = true;
            ShowNumericButtons = true;
        }

        public PagerPosition Position { get; set; }
        public bool ShowPageSizeItem { get; set; }
        public bool ShowDisabledButtons { get; set; }
        public bool ShowNumericButtons { get; set; }
        public bool ShowSeparators { get; set; }
        public PagerPageSizePosition PageSizeItemPosition { get; set; }
        public bool ShowSummary { get; set; }
    }
}
