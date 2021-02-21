using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class FixedRowsDemoOptions {
        public FixedRowsDemoOptions() {
            EnableFixedRows = true;
            EnableVerticalScrolling = false;
        }

        public bool EnableFixedRows { get; set; }
        public bool EnableVerticalScrolling { get; set; }
    }
}
