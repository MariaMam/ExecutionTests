using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class FilterBuilderDemoOptions {
        public FilterBuilderDemoOptions() {
            EnableTextTab = true;
            AllowHierarchicalColumns = true;
            ShowAllDataSourceColumns = true;
        }

        public bool EnableTextTab { get; set; }
        public bool AllowHierarchicalColumns { get; set; }
        public bool ShowAllDataSourceColumns { get; set; }
    }
}
