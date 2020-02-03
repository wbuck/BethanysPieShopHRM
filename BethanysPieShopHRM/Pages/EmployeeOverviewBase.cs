using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }


        protected override async Task OnInitializedAsync( )
        {
            Employees = await EmployeeDataService.GetAllEmployees( );
            await base.OnInitializedAsync( );
        }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
