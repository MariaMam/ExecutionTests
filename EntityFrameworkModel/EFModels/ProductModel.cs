using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class ProductModel
    {
        public int ProductModelId { get; set; }
        public string Name { get; set; }
        public string CatalogDescription { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
