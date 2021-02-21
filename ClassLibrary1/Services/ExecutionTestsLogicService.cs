using EntityFrameworkModel.Models;
using ExecutionTestsLogic.Dtos;
using ExecutionTestsLogic.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExecutionTestsLogic.Services
{
    public class ExecutionTestsLogicService : IExecutionTestsLogicService
    {

        IExecutionTestsRepository _executionTestsRepository;

        public ExecutionTestsLogicService(IExecutionTestsRepository executionTestsRepository)
        {
            _executionTestsRepository = executionTestsRepository;
        }

        public IQueryable<ExecutionTestsDto> GetExecutionTests()
        {
            return _executionTestsRepository.GetExecutionTests();
        }


        public dynamic GetSelectionSetOptionItems()
        {
            return _executionTestsRepository.GetSelectionSetOptionItems();
        }

        public dynamic GetExecutionTestsForPivot()
        {
            return _executionTestsRepository.GetExecutionTestsForPivot();
        }
    }
}
