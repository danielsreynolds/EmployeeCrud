using DataLibrary.DataAccess;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstName, string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            var sql = @"insert into dbo.Employees (EmployeeId, FirstName, LastName, EmailAddress)
                            values (@EmployeeId, @FirstName, @LastName, @EmailAddress);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = "select Id, EmployeeId, FirstName, LastName, EmailAddress from dbo.Employees";
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static List<EmployeeModel> LoadEmployee(string employeeId)
        {
            string sql = @"select Id, EmployeeId, FirstName, LastName, EmailAddress from dbo.Employees where EmployeeId = " + employeeId;

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static void DeleteEmployee(int employeeId)
        {
            string sql = @"Delete from dbo.Employees where EmployeeId = " + employeeId;

            SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static int EditEmployee(int employeeId, string firstName, string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"UPDATE dbo.Employees
                            SET FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress
                            WHERE EmployeeId = @EmployeeId";

            return SqlDataAccess.SaveData(sql, data);
        }
    }
}
