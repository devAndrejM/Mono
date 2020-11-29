namespace Coreapp.ViewModels
{
    public class VehicleModelView
    {
        public int Id { get; set; }
        
        public int MakeId { get; set; }
       
        public string Name { get; set; }
        
        public string Abrv { get; set; }

        public VehicleMakeView Make { get; set; }
    }
}
