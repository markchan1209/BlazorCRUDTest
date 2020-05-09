using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using ToDoList.Data.Entity;
using ToDoList.Repository;

namespace ToDoList.Data
{
    public class EmployeeServiceDapper : IEmployeeRepository
    {
        IConfiguration _configuration;

        public EmployeeServiceDapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<bool> Create(Employees emp)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO EMPLOYEES (Name, Country, Gender) VALUES(@Name,@Country, @Gender)";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, emp);
            }
            return true;
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    return await dbConnection.QueryAsync<Employees>("SELECT * FROM EMPLOYEES");
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Employees> GetEmployeeById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM EMPLOYEES WHERE  EmployeeId=@EmployeeId";
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<Employees>(sQuery, new { EmployeeId = id });
            }
        }

        public async Task<bool> UpdateEmployee(Employees employee)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE  EMPLOYEES  SET Name=@Name , Country=@Country, Gender=@Gender WHERE  EmployeeId=@EmployeeId";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, employee);
            }
            
            
            return true;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM EMPLOYEES WHERE  EmployeeId=@EmployeeId";
                dbConnection.Open();
                await dbConnection.ExecuteAsync(sQuery, new { EmployeeId = id });
            }
            return true;
        }
    }
}
