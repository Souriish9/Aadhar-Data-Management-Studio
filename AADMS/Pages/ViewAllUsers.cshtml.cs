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
    public class ViewAllUsersModel : PageModel
    {
        [BindProperty]
        public List<User> user { get; set; }

        public void OnGet()
        {
            user = CurdOpsUser.getAllData().ToList();
        }
    }
}