using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public class BatchEditingDemoOptions {
        public BatchEditingDemoOptions() {
            StartEditAction = GridViewBatchStartEditAction.FocusedCellClick;
            HighlightDeletedRecords = true;
        }

        public GridViewBatchStartEditAction StartEditAction { get; set; }
        public bool HighlightDeletedRecords { get; set; }

        public void Assign(BatchEditingDemoOptions source) {
            StartEditAction = source.StartEditAction;
            HighlightDeletedRecords = source.HighlightDeletedRecords;
        }
    }
}
