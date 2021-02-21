using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class CategoriesDemoOptions {
        public CategoriesDemoOptions() {
            EnableRowExpandingAnimation = true;
            AllowRowExpanding = true;
            ShowCategoryIndents = false;
            EnableCallbackMode = false;
        }

        public bool EnableRowExpandingAnimation { get; set; }
        public bool AllowRowExpanding { get; set; }
        public bool ShowCategoryIndents { get; set; }
        public bool EnableCallbackMode { get; set; }
    }
}
