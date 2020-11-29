

using Coreapp.CRUD;
using Coreapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models.Repository
{
    public interface IVehicleService
    {
        Task<PaginatedList<VehicleMake>> GetAllMakes(Sorting sort, Filtering filter, int? pageNumber);

        Task<VehicleMake> AddMake(VehicleMake newMake);
        Task<VehicleMake> UpdateMake(VehicleMake editMake);
        Task<VehicleMake> DeleteMake(int? makeId);
        Task<VehicleMake> GetMakeById(int? makeId);

        
        /*------------------------------------------------------------------------------------------------------------*/
        
        Task<PaginatedList<VehicleModel>> GetAllModels(Sorting sort, Filtering filter, int? pageNumber);

        Task<VehicleModel> AddModel(VehicleModel newModel);
        Task<VehicleModel> UpdateModel(VehicleModel editModel);
        Task<VehicleModel> DeleteModel(int? modelId);
        Task<VehicleModel> GetModelById(int? modelId);

        Task<IEnumerable<VehicleModel>> GetModelsByMakeId(int? makeId);
    }
}
