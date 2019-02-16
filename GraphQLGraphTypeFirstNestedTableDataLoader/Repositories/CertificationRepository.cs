using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstNestedTableDataLoader
{
    public class CertificationRepository : ICertificaationRepository
    {
        private readonly GraphQLDemoContext _context;
        public CertificationRepository(GraphQLDemoContext context)
        {
            _context = context;
        }

        public async Task<ILookup<long, Certification>> GetCertificationByEmployee(IEnumerable<long> employeeIds)
        {
            var reviews = await _context.Certification.Where(a => employeeIds.Contains(a.EmployeeId)).ToListAsync();
            return reviews.ToLookup(r => r.EmployeeId);
        }

    }

}
