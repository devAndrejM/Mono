
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models.Repository
{
    public interface IMakeService
    {
        Task<List<VehicleMake>> GetAllMakes(string sortOrder, string searchString, int? pageNumber, int pageSize);

        Task<int> AddMake(VehicleMake newMake);
        Task<int> UpdateMake(VehicleMake editMake);
        Task<int> DeleteMake(int? makeId);
        
        
    }
}
