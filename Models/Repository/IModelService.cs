using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models.Repository
{
    public interface IModelService
    {
        Task<List<VehicleModel>> GetAllModels(string sortOrder, string searchString, int? pageNumber, int pageSize);

        Task<int> AddModel(VehicleModel newModel);
        Task<int> UpdateModel(VehicleModel editModel);
        Task<int> DeleteModel(int? modelId);
    }
}
