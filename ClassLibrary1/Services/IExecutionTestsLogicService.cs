using ExecutionTestsLogic.Dtos;
using System.Linq;

namespace ExecutionTestsLogic.Services
{
    public interface IExecutionTestsLogicService
    {
        public IQueryable<ExecutionTestsDto> GetExecutionTests();
        public dynamic GetSelectionSetOptionItems();

        public dynamic GetExecutionTestsForPivot();
    }
}