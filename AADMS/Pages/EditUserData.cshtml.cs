using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AADMS.CURD;
using AADMS.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AADMS.Pages
{
    public class EditUserDataModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            bool res = CurdOpsUser.UserLogin(user);

            if (res == true)
            {
                HttpContext.Session.SetString("aadno", user.UID);
                return RedirectToPage("EditData");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}