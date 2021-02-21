using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace EntityFrameworkModel.Models
{
    public partial class ExecutionTest
    {
        public double Id { get; set; }
        public double? ProductId { get; set; }
        public string MeasurementDate { get; set; }
        public double? CategoryId { get; set; }
        public double? ParameterId { get; set; }
        public double? ParameterSortOrder { get; set; }
        public double? ParameterPlausibilityCheck { get; set; }
        public double? ParameterPlausibilityMin { get; set; }
        public double? ParameterPlausibilityMax { get; set; }
        public double? ClimaticConditionId { get; set; }

        [Column(TypeName = "MeasureConditionId")]
        public double? MeasureConditionId { get; set; }
        public double? PeriodeId { get; set; }
        public double? PeriodeDuration { get; set; }
        public string Comment { get; set; }
        public string Picture { get; set; }
        public double? NotApplicable { get; set; }
        public double? SelectedOptionItemId { get; set; }
       
        [Column(TypeName = "Value")]
        public double? TestValue { get; set; }

        public virtual Category Category { get; set; }
        public virtual ClimateCondition ClimaticCondition { get; set; }
        public virtual MeasureCondition MeasureCondition { get; set; }
        public virtual Parameter Parameter { get; set; }
        public virtual Periode Periode { get; set; }
        public virtual Product Product { get; set; }
        public virtual SelectionSetOptionItem SelectedOptionItem { get; set; }
    }
}
