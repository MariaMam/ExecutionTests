using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionTestsLogic.Services
{
    class ExecutionTestsLogic
    {

        ExecutionTestsDBContext _dbContext;

        public ExecutionTestsController(ExecutionTestsDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
