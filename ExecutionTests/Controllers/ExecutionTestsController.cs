using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtreme.NETCore.Demos.Models.DataGrid;
using DevExtreme.NETCore.Demos.Models.Northwind;
using EntityFrameworkModel.Models;
using ExecutionTests.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevExtreme.NETCore.Demos.Controllers.ApiControllers
{

    [Route("api/[controller]/[action]")]
    public class ExecutionTestsController : Controller
    {
        ExecutionTestsDBContext _dbContext;

        public ExecutionTestsController(ExecutionTestsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        [HttpGet]
        public object GetExecutionTests(DataSourceLoadOptions loadOptions)
        {
            var query = _dbContext.ExecutionTests.Include(e => e.Parameter).Include(e=>e.Periode);
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
            var a = DataSourceLoader.Load(dtos, loadOptions);
            return a;
        }

        [HttpPut]
        public IActionResult UpdateExecutionTest(int key, string values)
        {
            var test = _dbContext.ExecutionTests.First(o => o.Id == key);
            JsonConvert.PopulateObject(values, test);

            if (!TryValidateModel(test))
                return BadRequest(ModelState);

            _dbContext.SaveChanges();

            return Ok(test);
        }

        private static string BuildPeriod(double? periodeDuration, string periodeName)
        {
            return periodeDuration.ToString() + " " + periodeName;
        }

        [HttpGet]
        public object GetPeriods(DataSourceLoadOptions loadOptions)
        {
            var dtos = _dbContext.ExecutionTests.Select(p => new PeriodDto()
            {
                PeriodeIdplusDuration = p.PeriodeDuration.ToString() +" " +p.Periode.Name.ToString(),
                PeriodeId = p.PeriodeId
            }).Distinct();
            return DataSourceLoader.Load(dtos, loadOptions);
        }

        [HttpGet]
        public object GetCategories(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.Categories, loadOptions);
        }


        [HttpGet]
        public object GetStorageConditions(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.ClimateConditions, loadOptions);
        }

        [HttpGet]
        public object GetMeasureConditions(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.MeasureConditions, loadOptions);
        }

        [HttpGet]
        public object GetParameters(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.MeasureConditions, loadOptions);
        }


        [HttpGet]
        public object GetProducts(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.Products, loadOptions);
        }

        [HttpGet]
        public object GetParametersNames(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.Parameters, loadOptions);
        }

        [HttpGet]
        public object GetSelectionSetOptionItems(DataSourceLoadOptions loadOptions)
        {
            var dtos = _dbContext.SelectionSetOptionItems.Select(s =>
            new SelectionSetOptionItemsDto(s.Id, s.ItemValue, s.ItemName, s.Description));

            var lookup = from i in _dbContext.SelectionSetOptionItems
                         let textprep = (i.ItemValue != 0 ? i.ItemValue.ToString() : "") + " " + i.ItemName + (i.Description != null ? " (" + i.Description + ")" : "")
                         let text = textprep.Trim() == "" ? "n.a" : textprep
                         select new
                         {
                             Value = i.Id,
                             Text = text
                         };

            try
            {
                var result = DataSourceLoader.Load(lookup, loadOptions);
                return DataSourceLoader.Load(lookup, loadOptions);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return DataSourceLoader.Load(dtos, loadOptions);
        }
    }

}
