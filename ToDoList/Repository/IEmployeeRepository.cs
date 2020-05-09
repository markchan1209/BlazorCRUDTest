using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ToDoList.Data.Entity;

namespace ToDoList.Repository
{
    public interface IEmployeeRepository
    {
        IDbConnection Connection { get; }

        Task<bool> Create(Employees emp);
        Task<bool> DeleteEmployee(int id);
        Task<Employees> GetEmployeeById(int id);
        Task<IEnumerable<Employees>> GetEmployees();
        Task<bool> UpdateEmployee(Employees employee);
    }
}
