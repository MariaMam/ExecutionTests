using EntityFrameworkModel.Models;
using ExecutionTestsLogic.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTestsLogic.Repos
{
    public class ExecutionTestsRepository : IExecutionTestsRepository
    {

        ExecutionTestsDBContext _dbContext;

        public ExecutionTestsRepository(ExecutionTestsDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IQueryable<ExecutionTestsDto> GetExecutionTests()
        {
            var query = _dbContext.ExecutionTests.Include(e => e.Parameter).Include(e => e.Periode);
            var dtos = query.Select(e => new ExecutionTestsDto()
            {
                Id = e.Id,
                ProductId = e.ProductId,
                CategoryId = e.CategoryId,
                ClimaticConditionId = e.ClimaticConditionId,
                MeasureConditionId = e.MeasureConditionId,
                PeriodeId = e.PeriodeId,
                PeriodeDuration = e.PeriodeDuration,
                PeriodeIdplusDuration = e.Periode.Name,
                ParameterId = e.ParameterId,
                ParameterPlausibilityCheck = e.ParameterPlausibilityCheck,
                ParameterPlausibilityMin = e.ParameterPlausibilityMin,
                ParameterPlausibilityMax = e.ParameterPlausibilityMax,
                ExperimentResult = e.Parameter.SelectionSetId != null ? e.SelectedOptionItemId : e.TestValue,
                SelectedOptionItemId = e.SelectedOptionItemId,
                TestValue = e.TestValue
            });

            return dtos;
        }


        public dynamic GetSelectionSetOptionItems()
        {
            var lookup = from i in _dbContext.SelectionSetOptionItems
                         let textprep = (i.ItemValue != 0 ? i.ItemValue.ToString() : "") + " " + i.ItemName + (i.Description != null ? " (" + i.Description + ")" : "")
                         let text = textprep.Trim() == "" ? "n.a" : textprep
                         select new
                         {
                             Value = i.Id,
                             Text = text
                         };
            return lookup;
        }

        public dynamic GetExecutionTestsForPivot()
        {
            var source = from e in _dbContext.ExecutionTests.Include(e => e.Parameter).Include(e => e.SelectedOptionItem)
                         let isSelectable = e.Parameter.ParameterType == "SelectionSet"
                         let textprep = isSelectable ? (e.SelectedOptionItem.ItemValue != 0 ? e.SelectedOptionItem.ItemValue.ToString() : "")
                         + " " + e.SelectedOptionItem.ItemName + (e.SelectedOptionItem.Description != null ? " (" + e.SelectedOptionItem.Description + ")" : "") : ""
                         let text = textprep.Trim() == "" ? "n.a" : textprep.Trim()
                         let isFailed = isSelectable ? e.SelectedOptionItem.IsFailed == 1 :
                         (e.ParameterPlausibilityCheck == 1 && (e.TestValue < e.ParameterPlausibilityMin || e.TestValue > e.ParameterPlausibilityMax))
                         select new
                         {
                             e.Id,
                             e.ProductId,
                             ProductName = e.Product.Name,
                             e.CategoryId,
                             CategoryName = e.Category.Name,
                             e.ClimaticConditionId,
                             ClimaticConditionName = e.ClimaticCondition.Name,
                             e.MeasureConditionId,
                             MeasureConditionName = e.MeasureCondition.Name,
                             e.PeriodeId,
                             e.PeriodeDuration,
                             PeriodeName = e.PeriodeDuration + " " + e.Periode.Name,
                             e.ParameterId,
                             ParameterName = e.Parameter.Name,
                             e.ParameterPlausibilityCheck,
                             e.ParameterPlausibilityMin,
                             e.ParameterPlausibilityMax,
                             e.SelectedOptionItemId,
                             TestValue = isSelectable ? text : e.TestValue.ToString().Trim(),
                             IsFailed = isFailed
                         };


            return source;
        }
    }
}
