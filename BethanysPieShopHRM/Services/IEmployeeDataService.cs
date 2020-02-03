using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Services
{
    public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees( );

        Task<Employee> GetEmployeeDetails( int employeeID );

        Task<Employee> AddEmployee( Employee employee );

        Task UpdateEmployee( Employee employee );

        Task DeleteEmployee( int employeeID );
    }
}
