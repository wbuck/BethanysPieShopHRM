using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Components
{
    public class AddEmployeeDialogBase : ComponentBase
    {
        private bool _showDialog;

        public Employee Employee { get; set; } = new Employee
        {
            CountryId = 1,
            JobCategoryId = 1,
            BirthDate = DateTime.Now,
            JoinedDate = DateTime.Now
        };

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; } 

        public bool ShowDialog
        {
            get { return _showDialog; }
            set
            {
                if ( _showDialog == value ) return;
                _showDialog = value;
                StateHasChanged( );
            }
        }

        public void Show( )
        {
            ResetDialog( );
            ShowDialog = true;            
        }

        public void Close( ) => ShowDialog = false;

        protected async Task HandleValidSubmit( )
        {
            await EmployeeDataService.AddEmployee( Employee );
            await CloseEventCallback.InvokeAsync( true );
            ShowDialog = false;
        }        

        private void ResetDialog( ) =>
            Employee = new Employee
            {
                CountryId = 1,
                JobCategoryId = 1,
                BirthDate = DateTime.Now,
                JoinedDate = DateTime.Now
            };


    }
}
