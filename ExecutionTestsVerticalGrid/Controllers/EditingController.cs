using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.Web.Demos.Mvc;


namespace DevExpress.Web.Demos {
    public partial class EditingController: DemoController {
        public override string Name { get { return "Editing"; } }

        public ActionResult Index() {
            return RedirectToAction("BatchEditing");
        }

        public ActionResult BatchEditing() {
            return DemoView("BatchEditing", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost]
        public ActionResult BatchEditing(BatchEditingDemoOptions options) {
            BatchEditingDemoHelper.Options.Assign(options);
            return DemoView("BatchEditing", NorthwindDataProvider.GetEditableProducts());
        }
        public ActionResult BatchEditingPartial(BatchEditingDemoOptions options) {
            BatchEditingDemoHelper.Options.Assign(options);
            return PartialView("BatchEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [ValidateInput(false)]
        public ActionResult BatchEditingUpdateModel(MVCxGridViewBatchUpdateValues<EditableProduct, int> updateValues) {
            foreach(var product in updateValues.Insert) {
                if(updateValues.IsValid(product))
                    InsertProduct(product, updateValues);
            }
            foreach(var product in updateValues.Update) {
                if(updateValues.IsValid(product))
                    UpdateProduct(product, updateValues);
            }
            foreach(var productID in updateValues.DeleteKeys) {
                DeleteProduct(productID, updateValues);
            }
            return PartialView("BatchEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }

        protected void InsertProduct(EditableProduct product, MVCxGridViewBatchUpdateValues<EditableProduct, int> updateValues) {
            try {
                NorthwindDataProvider.InsertProduct(product);
            }
            catch(Exception e) {
                updateValues.SetErrorText(product, e.Message);
            }
        }
        protected void UpdateProduct(EditableProduct product, MVCxGridViewBatchUpdateValues<EditableProduct, int> updateValues) {
            try {
                NorthwindDataProvider.UpdateProduct(product);
            }
            catch(Exception e) {
                updateValues.SetErrorText(product, e.Message);
            }
        }
        protected void DeleteProduct(int productID, MVCxGridViewBatchUpdateValues<EditableProduct, int> updateValues) {
            try {
                NorthwindDataProvider.DeleteProduct(productID);
            }
            catch(Exception e) {
                updateValues.SetErrorText(productID, e.Message);
            }
        }
    }
}
