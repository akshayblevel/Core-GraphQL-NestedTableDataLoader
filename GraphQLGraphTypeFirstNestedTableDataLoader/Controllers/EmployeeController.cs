using GraphQL.Client;
using GraphQL.Common.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQLGraphTypeFirstNestedTableDataLoader.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            using (GraphQLClient graphQLClient = new GraphQLClient("http://localhost:64666/graphql"))
            {
                var query = new GraphQLRequest
                {
                    Query = @" 
                        { employees 
                            { name 
                              email  
                              certifications
                                 { title }
                            }
                        }",
                };
                var response = await graphQLClient.PostAsync(query);
                return response.GetDataFieldAs<List<Employee>>("employees");
            }
        }
    }
}
