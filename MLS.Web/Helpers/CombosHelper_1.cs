using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLS.Web.Helpers
{
    public class CombosHelper_1
    {
        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> list = new List<SelectListItem>
            {
                
                new SelectListItem { Value = "1", Text = "Userpaciente" },
               
            };

            return list;
             }
}
}
