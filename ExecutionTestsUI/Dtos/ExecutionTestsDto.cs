using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionTests.Dtos
{
    public class ExecutionTestsDto
    {

        public double Id { get; set; }
        public double? ProductId { get; set; }
        public double? CategoryId { get; set; }
        public double? ClimaticConditionId { get; set; }
        public double? MeasureConditionId { get; set; }
        public double? PeriodeId { get; set; }
        public double? PeriodeDuration { get; set; }
        public double? ParameterId { get; set; }
        public double? ParameterSortOrder { get; set; }
        public double? ParameterPlausibilityCheck { get; set; }
        public double? ParameterPlausibilityMin { get; set; }
        public double? ParameterPlausibilityMax { get; set; }
        public double? ExperimentResult { get; set; }
        public double? SelectedOptionItemId { get; set; }
        public double? TestValue { get; set; }
        public string PeriodeIdplusDuration { get; set; }
    }
}
