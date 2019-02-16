using GraphQL.DataLoader;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstNestedTableDataLoader
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(ICertificaationRepository certificationRepository, IDataLoaderContextAccessor dataLoaderContextAccessor)
        {
            Field(a => a.Id);
            Field(a => a.Name);
            Field(a => a.Email);
            Field(a => a.Mobile);
            Field(a => a.Company);
            Field(a => a.Address);
            Field(a => a.ShortDescription);
            Field(a => a.LongDescription);

            Field<ListGraphType<EmployeeCertificationType>>(
                "certifications",
                resolve: context =>
                {
                    var loader = dataLoaderContextAccessor.Context.GetOrAddCollectionBatchLoader<long, Certification>(
                        "GetCertificationByEmployee", certificationRepository.GetCertificationByEmployee);

                    return loader.LoadAsync(context.Source.Id);
                });


        }
    }

}
