using System.Web.Mvc;
using System.Collections;
using System.Linq;
using System.Data.Entity;
using DevExpress.Web.Demos.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TemplatesController: DemoController {
        public override string Name { get { return "Templates"; } }

        public ActionResult Index() {
            return RedirectToAction("DataCell");
        }

        public ActionResult DataCell() {
            return DemoView("DataCell", GetCategoriesWithProducts());
        }

        public ActionResult DataCellPartial() {
            return PartialView("DataCellPartial", GetCategoriesWithProducts());
        }

        IEnumerable GetCategoriesWithProducts() {
            return NorthwindDataProvider.DB.Categories.Select(category => new {
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture,
                ProductNames = category.Products.Select(p => p.ProductName)
            }).ToList();
        }
    }
}
