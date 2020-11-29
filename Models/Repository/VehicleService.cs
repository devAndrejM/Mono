using Coreapp.CRUD;
using Coreapp.Data;
using Coreapp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.Models.Repository
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleDbContext db;

        public VehicleService(VehicleDbContext _db)
        {
            db = _db;
        }
        public async Task<VehicleMake> AddMake(VehicleMake newMake)
        {           
                db.VehicleMakes.Add(newMake);
                await db.SaveChangesAsync();
                return newMake;            
        }

        public async Task<VehicleModel> AddModel(VehicleModel newModel)
        {
            db.VehicleModels.Add(newModel);
            await db.SaveChangesAsync();
            return newModel;
        }

        public async Task<VehicleMake> DeleteMake(int? makeId)
        {
            
                VehicleMake make = await db.VehicleMakes.FirstOrDefaultAsync(m => m.Id == makeId);
                if (make != null)
                {
                    db.Remove(make);
                    await db.SaveChangesAsync();
                }
            return make;
        }

        public async Task<VehicleModel> DeleteModel(int? modelId)
        {
            VehicleModel model = await db.VehicleModels.FirstOrDefaultAsync(m => m.Id == modelId);
            if (model != null)
            {
                db.Remove(model);
                await db.SaveChangesAsync();
            }
            return model;
        }

        public async Task<PaginatedList<VehicleMake>> GetAllMakes(Sorting sort, Filtering filter, int? pageNumber)
        {
            var makes = from m in db.VehicleMakes
                        select m;

            if (filter.SearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                filter.SearchString = filter.CurrentFilter;
            }

            if (!String.IsNullOrEmpty(filter.SearchString))
            {
                makes = makes.Where(m => m.Name.Contains(filter.SearchString)
                                    || m.Abrv.Contains(filter.SearchString));

            }
            makes = sort.SortOrder switch
            {
                "name_desc" => makes.OrderByDescending(m => m.Name),
                "Abrv" => makes.OrderBy(m => m.Abrv),
                "abrv_desc" => makes.OrderByDescending(m => m.Abrv),
                _ => makes.OrderBy(m => m.Name),
            };
            
            int pageSize = 8;

            return await PaginatedList<VehicleMake>.CreateAsync(makes.AsNoTracking(), pageNumber ?? 1, pageSize);

        }

        public async Task<PaginatedList<VehicleModel>> GetAllModels(Sorting sort, Filtering filter, int? pageNumber)
        {
            var models = from m in db.VehicleModels.Include(m => m.Make) select m;

            if (filter.SearchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                filter.SearchString = filter.CurrentFilter;
            }

            if (!String.IsNullOrEmpty(filter.SearchString))
            {
                models = models.Where(m => m.Name.Contains(filter.SearchString)
                                    || m.Abrv.Contains(filter.SearchString)
                                    || m.Make.Name.Contains(filter.SearchString));
            }

            models = sort.SortOrder switch
            {
                "name_desc" => models.OrderByDescending(m => m.Name),
                "make_desc" => models.OrderByDescending(m => m.Make),
                "Abrv" => models.OrderBy(m => m.Abrv),
                "abrv_desc" => models.OrderByDescending(m => m.Abrv),
                _ => models.OrderBy(m => m.Name),
            };
            
            int pageSize = 8;

            return await PaginatedList<VehicleModel>.CreateAsync(models.AsNoTracking(), pageNumber ?? 1, pageSize);

        }

        public async Task<VehicleMake> GetMakeById(int? makeId)
        {
            return await db.VehicleMakes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == makeId);
        }

        public async Task<VehicleModel> GetModelById(int? modelId)
        {
            return await db.VehicleModels.AsNoTracking().FirstOrDefaultAsync(x => x.Id == modelId);
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByMakeId(int? makeId)
        {
            return await db.VehicleModels.Where(m => m.MakeId == makeId).ToListAsync();
        }

        public async Task<VehicleMake> UpdateMake(VehicleMake editMake)
        {
            db.Entry(editMake).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return editMake;
        }

        public async Task<VehicleModel> UpdateModel(VehicleModel editModel)
        {
            db.Entry(editModel).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return editModel;
        }
    }
}
