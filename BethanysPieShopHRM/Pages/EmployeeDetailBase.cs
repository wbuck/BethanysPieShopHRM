﻿using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Parameter]
        public string EmployeeID { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public Employee Employee { get; set; } = new Employee( );

        protected override async Task OnInitializedAsync( )
        {
            Employee = await EmployeeDataService.GetEmployeeDetails( int.Parse( EmployeeID ) );
            await base.OnInitializedAsync( );
        }

        
    }
}
