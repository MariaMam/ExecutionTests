using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class ProductModelProductDescription
    {
        public int ProductModelId { get; set; }
        public int ProductDescriptionId { get; set; }
        public string Culture { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
