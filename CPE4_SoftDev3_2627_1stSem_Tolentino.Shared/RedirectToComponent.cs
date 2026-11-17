using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Components;

namespace CPE4_SoftDev3_2627_1stSem_Tolentino.Shared
{
    internal class RedirectToLogin : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized() =>
        NavigationManager.NavigateTo("/login", replace: true);
  
    }
}
