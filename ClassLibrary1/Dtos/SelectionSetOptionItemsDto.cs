using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionTestsLogic.Dtos
{
    public class SelectionSetOptionItemsDto
    {
        public SelectionSetOptionItemsDto(double id ,double? itemValue, string itemName, string itemDescription)
        {
            SelectionSetOptionItemId = id;
            ItemText = (itemValue !=0 ? itemValue.ToString():"") + " "+ itemName + (itemDescription != null ?" (" +itemDescription+")":"");
            ItemText = ItemText.Trim() == "" ? "n.a" : ItemText;
        }

        public double SelectionSetOptionItemId { get; set; }
        public string ItemText { get; set; }

    }
}
