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
    public class EditDataModel : PageModel
    {
        CurdOpsUser op = new CurdOpsUser();

        [BindProperty]
        public string AID { get; set; }

        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {
            AID = HttpContext.Session.GetString("aadno");
            user = CurdOpsUser.getDataByAID(AID);
        }

        public ActionResult OnPost(User user)
        {
            bool res = CurdOpsUser.EditUser(user);

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