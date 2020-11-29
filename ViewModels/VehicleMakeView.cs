using System.Collections.Generic;

namespace Coreapp.ViewModels
{
    public class VehicleMakeView
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }

        public IEnumerable<VehicleModelView> VehicleModels { get; set; }
    }
}
