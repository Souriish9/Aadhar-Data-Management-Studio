using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AADMS.CURD;
using AADMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AADMS.Pages
{
    public class AddAdminModel : PageModel
    {
        [BindProperty]
        public Admin admin { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            bool result = CurdOpsAdmin.AddAdmin(admin);

            if (result == true)
            {
                return RedirectToPage("AdminHome");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}