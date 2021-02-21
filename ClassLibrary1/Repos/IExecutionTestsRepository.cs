using ExecutionTestsLogic.Dtos;
using System.Linq;

namespace ExecutionTestsLogic.Repos
{
    public interface IExecutionTestsRepository
    {
        public IQueryable<ExecutionTestsDto> GetExecutionTests();
        public dynamic GetSelectionSetOptionItems();

        public dynamic GetExecutionTestsForPivot();
    }
}