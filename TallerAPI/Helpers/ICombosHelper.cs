using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TallerAPI.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboDocumentTypes();

        IEnumerable<SelectListItem> GetComboProcedures();

        IEnumerable<SelectListItem> GetComboVehicleTypes();

        IEnumerable<SelectListItem> GetComboBrands();
    }
}
