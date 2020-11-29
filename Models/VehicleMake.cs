using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Coreapp.Models
{

    public class VehicleMake
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 letters")]
        [Display(Name = "Make Name")]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Abbreviation should be shorther than name. Max. of 30 letters!")]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }


        public IEnumerable<VehicleModel> VehicleModels { get; set; }
    }
}
