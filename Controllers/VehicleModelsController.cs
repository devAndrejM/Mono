using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coreapp.Data;
using Coreapp.Models;
using Coreapp.Paging;

namespace Coreapp.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly VehicleDbContext _context;

        public VehicleModelsController(VehicleDbContext context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["MakeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "make_desc" : "";
            ViewData["AbrvSortParm"] = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            
            var models = from m in _context.VehicleModels.Include(m => m.Make) select m;
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
            int pageSize = 5;
            return View(await PaginatedList<VehicleModel>.CreateAsync(models.AsNoTracking(), pageNumber ?? 1, pageSize));




        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.Make)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakeId,Name,Abrv")] VehicleModel vehicleModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(vehicleModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var modelToUpdate = await _context.VehicleModels.FirstOrDefaultAsync(m => m.Id == id);
            if(await TryUpdateModelAsync<VehicleModel>(modelToUpdate,"",m => m.Name, m=> m.Abrv))
           
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                
            }
            //ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.MakeId);
            return View(modelToUpdate);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.Make)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if(vehicleModel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.VehicleModels.Remove(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }

        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModels.Any(e => e.Id == id);
        }
    }
}
