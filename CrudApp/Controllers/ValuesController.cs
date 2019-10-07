using CrudApp.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using static DataLibrary.BusinessLogic.EmployeeProcessor;

namespace CrudApp.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<EmployeeModel> Get()
        {
            var data = LoadEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName.Trim(),
                    LastName = row.LastName.Trim(),
                    EmailAddress = row.EmailAddress.Trim(),
                });
            }


            return employees;
            //            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public List<EmployeeModel> Get(string id)
        {
            var data = LoadEmployee(id);

            List<EmployeeModel> employee = new List<EmployeeModel>();

            foreach (var row in data)
            {
                employee.Add(new EmployeeModel
                {
                    EmployeeId = row.EmployeeId,
                    FirstName = row.FirstName.Trim(),
                    LastName = row.LastName.Trim(),
                    EmailAddress = row.EmailAddress.Trim()
                });
            }

            return employee;
        }

        // POST api/values
        public void Post([FromBody]EmployeeModel model)
        {
            CreateEmployee(model.EmployeeId, model.FirstName, model.LastName, model.EmailAddress);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]EmployeeModel model)
        {
            if (model != null)
            {
                EditEmployee(id, model.FirstName, model.LastName, model.EmailAddress);
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            DeleteEmployee(id);
        }
    }
}
