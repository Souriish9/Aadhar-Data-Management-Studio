using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AADMS.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace AADMS.Pages
{
    public class HomeModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        [BindProperty]
        public User user1 { get; set; }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            bool res = CURD.CurdOpsUser.UserLogin(user);

            if(res==true)
            {
                HttpContext.Session.SetString("aadno", user.UID);
                return RedirectToPage("UserHome");
            }
            else
            {
                return RedirectToPage("./Error");
            }
        }
    }
}