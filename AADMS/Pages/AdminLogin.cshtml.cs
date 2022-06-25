using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AADMS.Model;
using AADMS.CURD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AADMS.Pages
{
    public class AdminLoginModel : PageModel
    {

        [BindProperty]
        public Admin admin { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            bool res = CurdOpsAdmin.Login(admin);
            if (res == true)
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