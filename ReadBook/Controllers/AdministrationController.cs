using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ReadBook.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager) 
        {
            this._roleManager = roleManager;
        }

        
    }
}
