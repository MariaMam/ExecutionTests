using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EntityFrameworkModel.Models;
using ExecutionTestsLogic.Dtos;
using ExecutionTestsLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevExtreme.NETCore.Demos.Controllers.ApiControllers
{

    [Route("api/[controller]/[action]")]
    public class ExecutionTestsController : Controller
    {
        ExecutionTestsDBContext _dbContext;
        IExecutionTestsLogicService _executionTestsLogicService;

        public ExecutionTestsController(ExecutionTestsDBContext dbContext, IExecutionTestsLogicService executionTestsLogicService)
        {
            _dbContext = dbContext;
            _executionTestsLogicService = executionTestsLogicService;
        }


        [HttpGet]
        public object GetExecutionTests(DataSourceLoadOptions loadOptions)
        {
            var dtos = _executionTestsLogicService.GetExecutionTests();
            var a = DataSourceLoader.Load(dtos, loadOptions);
            return a;
        }

        [HttpGet]
        public async Task<IActionResult> GetExecutionTestsPivot(DataSourceLoadOptions loadOptions)
        {
            var source = _executionTestsLogicService.GetExecutionTestsForPivot();

            loadOptions.PrimaryKey = new[] { "Id" };
            loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(source, loadOptions));
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
                PeriodeIdplusDuration = p.PeriodeDuration.ToString() + " " + p.Periode.Name.ToString(),
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
            var lookup = _executionTestsLogicService.GetSelectionSetOptionItems();
            return DataSourceLoader.Load(lookup, loadOptions);

        }
    }

}
