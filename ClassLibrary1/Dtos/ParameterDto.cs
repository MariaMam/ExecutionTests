using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExecutionTestsLogic.Dtos
{
    public class ParameterDto
    {
        public double? ParameterId { get; set; }
        public double? ParameterSortOrder { get; set; }
        public double? ParameterPlausibilityCheck { get; set; }
        public double? ParameterPlausibilityMin { get; set; }
        public double? ParameterPlausibilityMax { get; set; }
        public double? ExperimentResult { get; set; }
        public double? SelectionSetOptionItemId { get; set; }
        public double? TestValue { get; set; }
    }
}
