using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AADMS.Model
{
    public class User
    {
        [BindProperty]
        public string UID { get; set; }

        [BindProperty]
        public string FIRSTNAME { get; set; }

        [BindProperty]
        public string LASTNAME { get; set; }

        [BindProperty]
        public string DOB { get; set; }

        [BindProperty]
        public string PHONE { get; set; }

        [BindProperty]
        public string EMAIL { get; set; }

        [BindProperty]
        public string OCCUPATION { get; set; }

        [BindProperty]
        public string GENDER { get; set; }

        [BindProperty]
        public string MARTIALSTAT { get; set; }

        [BindProperty]
        public string ADD_LINE1 { get; set; }

        [BindProperty]
        public string ADD_LINE2 { get; set; }

        [BindProperty]
        public string POSTALCODE { get; set; }

        [BindProperty]
        public string CITY { get; set; }

        [BindProperty]
        public string STATE { get; set; }

        [BindProperty]
        public string COUNTRY { get; set; }

        [BindProperty]
        public string CO_FNAME { get; set; }

        [BindProperty]
        public string CO_LNAME { get; set; }
    }
}
