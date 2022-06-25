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
    public class AddUserDataModel : PageModel
    {
        CurdOpsUser op = new CurdOpsUser();

        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            bool result1 = op.AddUser(user);
            //bool result2 = op.CheckDuplicate(user);

            if (result1 == true)
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