using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstNestedTableDataLoader
{
    public interface ICertificaationRepository
    {
        Task<ILookup<long, Certification>> GetCertificationByEmployee(IEnumerable<long> employeeIds);
    }

}
