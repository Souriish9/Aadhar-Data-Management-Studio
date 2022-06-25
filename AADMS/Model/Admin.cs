using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AADMS.Model
{
    public class Admin
    {
        [BindProperty]
        public int USERID { get; set; }

        [BindProperty]
        public String NAME { get; set; }

        [BindProperty]
        public String EMAIL { get; set; }

        [BindProperty]
        public String PASSWORD { get; set; }

        [BindProperty]
        public String DEPARTMENT { get; set; }
    }
}
