﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models
{
    
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(VehicleMake))]
        public int MakeId { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(50, ErrorMessage = "Maximum 50 letters")]
        [Display(Name="Model Name")]
        public string Name { get; set; }
        [StringLength(30, ErrorMessage = "Abbreviation should be shorther than name. Max. of 30 letters!")]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }

        public VehicleMake Make { get; set; }
    }

}
