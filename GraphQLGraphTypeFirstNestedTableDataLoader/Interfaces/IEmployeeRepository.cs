using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstNestedTableDataLoader
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
    }

}
