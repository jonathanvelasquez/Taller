using System;
using System.ComponentModel.DataAnnotations;

namespace TallerAPI.Data.Entities
{
    public class VehiclePhoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        //TODO: Fix Foto
        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44338/images/NotImage.png"
            : $"https://vehiclessalazar.blob.core.windows.net/vehicles/{ImageId}";
    }
}
