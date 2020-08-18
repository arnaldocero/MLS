using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MLS.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
    }
}
