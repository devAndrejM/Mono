using Coreapp.Data;
using Coreapp.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models.Repository
{
    public class VehicleService : IMakeService, IModelService
    {
        private readonly VehicleDbContext db;

        public VehicleService(VehicleDbContext _db)
        {
            db = _db;
        }
        public async Task<int> AddMake(VehicleMake newMake)
        {
            if(db!=null)
            {
                db.VehicleMakes.Add(newMake);
                await db.SaveChangesAsync();
                return newMake.Id;
            }
            return 0;
        }

        public async Task<int> AddModel(VehicleModel newModel)
        {
            if (db != null)
            {
                db.VehicleModels.Add(newModel);
                await db.SaveChangesAsync();
                return newModel.Id;
            }
            return 0;
        }

        public async Task<int> DeleteMake(int? makeId)
        {
            int result = 0;
            if (db != null)
            {                
                var make = await db.VehicleMakes.FirstOrDefaultAsync(m => m.Id == makeId);
                if (make != null)
                {
                    db.VehicleMakes.Remove(make);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
    

        public async Task<int> DeleteModel(int? modelId)
        {
        int result = 0;
        if (db != null)
        {
            var model = await db.VehicleModels.FirstOrDefaultAsync(m => m.Id == modelId);
            if (model != null)
            {
                db.VehicleModels.Remove(model);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        return result;
    }


        public async Task<List<VehicleMake>> GetAllMakes(string sortOrder, string searchString, int? pageNumber, int pageSize)
        {
            if(db !=null)
            {
                var makes = from m in db.VehicleMakes
                            select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    makes = makes.Where(m => m.Name.Contains(searchString)
                                        || m.Abrv.Contains(searchString));

                }
                makes = sortOrder switch
                {
                    "name_desc" => makes.OrderByDescending(m => m.Name),
                    "Abrv" => makes.OrderBy(m => m.Abrv),
                    "abrv_desc" => makes.OrderByDescending(m => m.Abrv),
                    _ => makes.OrderBy(m => m.Name),
                };
                return await PaginatedList<VehicleMake>.CreateAsync(makes.AsNoTracking(), pageNumber ?? 1, pageSize);
            }
            return null;
        }

        public async Task<List<VehicleModel>> GetAllModels(string sortOrder, string searchString, int? pageNumber, int pageSize)
        {
            if(db != null)
            {
                var models = from m in db.VehicleModels.Include(m => m.Make) select m;
                if (!String.IsNullOrEmpty(searchString))
                {
                    models = models.Where(m => m.Name.Contains(searchString)
                                        || m.Abrv.Contains(searchString)
                                        || m.Make.Name.Contains(searchString));
                }

                models = sortOrder switch
                {
                    "name_desc" => models.OrderByDescending(m => m.Name),
                    "make_desc" => models.OrderByDescending(m => m.Make),
                    "Abrv" => models.OrderBy(m => m.Abrv),
                    "abrv_desc" => models.OrderByDescending(m => m.Abrv),
                    _ => models.OrderBy(m => m.Name),
                };
                return await PaginatedList<VehicleModel>.CreateAsync(models.AsNoTracking(), pageNumber ?? 1, pageSize);
            }
            return null;
        }

        public async Task<int> UpdateMake(VehicleMake editMake)
        {
            if(db != null)
            {
                db.Entry(editMake).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return editMake.Id;
            }
            return 0;
        }

        public async Task<int> UpdateModel(VehicleModel editModel)
        {
            if (db != null)
            {
                db.Entry(editModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return editModel.Id;
            }
            return 0;
        }
    }
}
