

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using DevExtreme.AspNet.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkModel.Models;
using DevExtreme.AspNet.Mvc;

namespace ExecutionTests.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExecutionTestsPivotController : Controller
    {

        ExecutionTestsDBContext _dbContext;

        public ExecutionTestsPivotController(ExecutionTestsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetExecutionTests(DataSourceLoadOptions loadOptions)
        {
            var source = from e in _dbContext.ExecutionTests.Include(e => e.Parameter).Include(e => e.SelectedOptionItem)
                         let isSelectable = e.Parameter.ParameterType == "SelectionSet"
                         let textprep = isSelectable ?(e.SelectedOptionItem.ItemValue != 0 ? e.SelectedOptionItem.ItemValue.ToString() : "") 
                         + " " + e.SelectedOptionItem.ItemName + (e.SelectedOptionItem.Description != null ? " (" + e.SelectedOptionItem.Description + ")" : ""):""
                         let text = textprep.Trim() == "" ? "n.a" : textprep.Trim()
                         let isFailed = isSelectable ? e.SelectedOptionItem.IsFailed == 1 : 
                         ( e.ParameterPlausibilityCheck == 1 && (e.TestValue < e.ParameterPlausibilityMin || e.TestValue > e.ParameterPlausibilityMax))
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
                             PeriodeName = e.PeriodeDuration +" " +e.Periode.Name,
                             e.ParameterId,
                             ParameterName = e.Parameter.Name,
                             e.ParameterPlausibilityCheck,
                             e.ParameterPlausibilityMin,
                             e.ParameterPlausibilityMax,
                             e.SelectedOptionItemId,
                             TestValue = isSelectable? text : e.TestValue.ToString().Trim(),
                             IsFailed = isFailed
                         };

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(source, loadOptions));
        }        
    }
}
