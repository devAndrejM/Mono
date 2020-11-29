using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coreapp.Data;
using Coreapp.Models;
using Coreapp.Models.Repository;
using AutoMapper;
using Coreapp.ViewModels;
using Coreapp.CRUD;


namespace Coreapp.Controllers
{
    public class VehicleModelsController : Controller
    {
        private readonly VehicleDbContext _context;
        private readonly IVehicleService _modelService;
        private readonly IMapper _mapper;
        private PaginatedList<VehicleModelView> vehicleModels;

        public VehicleModelsController(VehicleDbContext context, IVehicleService modelService, IMapper mapper)
        {
            _context = context;
            _modelService = modelService;
            _mapper = mapper;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index(Sorting sort, Filtering filter, int? pageNumber)
        {
            sort = new Sorting(sort.SortOrder);
            filter = new Filtering(filter.SearchString, filter.CurrentFilter);

            ViewBag.CurrentSort = sort.SortOrder;
            ViewBag.sortByMake = sort.SortOrder == "make_desc" ? "make_asc" : "make_desc";
            ViewBag.sortByName = string.IsNullOrEmpty(sort.SortOrder) ? "name_desc" : "";
            ViewBag.sortByAbrv = sort.SortOrder == "abrv_desc" ? "abrv_asc" : "abrv_desc";
            ViewBag.CurrentFilter = filter.SearchString;

            var models = await _modelService.GetAllModels(sort, filter, pageNumber);
            
            
            vehicleModels = new PaginatedList<VehicleModelView>(_mapper.Map<List<VehicleModelView>>(models), models.Count, models.PageIndex ?? 1, models.PageSize);                         

            return View(vehicleModels);


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
                    
                    await _modelService.AddModel(vehicleModel);
                    
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
            var model = _mapper.Map<VehicleModelView>(vehicleModel);
            return View(model);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehicleModel = await _modelService.GetModelById(id);
            if (id == null)
            {
                return NotFound();
            }
           
            
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.MakeId);
            var model = _mapper.Map<VehicleModelView>(vehicleModel);
            return View(model);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("MakeId,Name,Abrv")] VehicleModel vehicleModel)
        {

            
            try
            {
                if (ModelState.IsValid)
                {

                    await _modelService.UpdateModel(vehicleModel);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
                
            
            ViewData["MakeId"] = new SelectList(_context.VehicleMakes, "Id", "Name", vehicleModel.MakeId);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _modelService.GetModelById(id);
            
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
            
            try
            {
                await _modelService.DeleteModel(id);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }

        }

        //private bool VehicleModelExists(int id)
        //{
        //    return _context.VehicleModels.Any(e => e.Id == id);
        //}
    }
}
