using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coreapp.Models;
using Coreapp.Models.Repository;
using AutoMapper;
using Coreapp.ViewModels;
using Coreapp.CRUD;


namespace Coreapp.Controllers
{
    public class VehicleMakesController : Controller
    {
        
        private readonly IVehicleService _makeService;
        private readonly IMapper _mapper;
        private PaginatedList<VehicleMakeView> vehicleMakes;

        public VehicleMakesController(IVehicleService makeService, IMapper mapper)
        {
            _makeService = makeService; ;
            _mapper = mapper;            
            
        }

        // GET: VehicleMakes
        public async Task<IActionResult> Index(Sorting sort, Filtering filter, int? pageNumber)
        {
            sort = new Sorting(sort.SortOrder);
            filter = new Filtering(filter.SearchString, filter.CurrentFilter);

            ViewBag.CurrentSort = sort.SortOrder;
            ViewBag.sortByName = string.IsNullOrEmpty(sort.SortOrder) ? "name_desc" : "";
            ViewBag.sortByAbrv = sort.SortOrder == "abrv_desc" ? "abrv_asc" : "abrv_desc";
            ViewBag.CurrentFilter = filter.SearchString;
            
            var makes = await _makeService.GetAllMakes(sort, filter, pageNumber);

            vehicleMakes = new PaginatedList<VehicleMakeView>(_mapper.Map<List<VehicleMakeView>>(makes),makes.Count, makes.PageIndex ?? 1, makes.PageSize);

            return View(vehicleMakes);
        }

        // GET: VehicleMakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var vehicleMake = await _makeService.GetMakeById(id);
            vehicleMake.VehicleModels = await _makeService.GetModelsByMakeId(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }
            var makeView = _mapper.Map<VehicleMakeView>(vehicleMake);
            return View(makeView);
            
        }

        // GET: VehicleMakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Abrv")] VehicleMake vehicleMake)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    await _makeService.AddMake(vehicleMake);
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            var create = _mapper.Map<VehicleMakeView>(vehicleMake);
            return View(create);
        }

        // GET: VehicleMakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehicleMake = await _makeService.GetMakeById(id);
            if (id == null)
            {
                return NotFound();
            }
            var make = _mapper.Map<VehicleMakeView>(vehicleMake);
            
            if (vehicleMake == null)
            {
                return NotFound();
            }
            return View(make);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, [Bind("Id,Name,Abrv")] VehicleMake vehicleMake)
        {
            
           {
                var make = await _makeService.GetMakeById(id);
                if(make.Id != id)
                {
                    return NotFound();
                }
                try
                {
                    await _makeService.UpdateMake(vehicleMake);
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
            var edited = _mapper.Map<VehicleMakeView>(vehicleMake);
            return View(edited);
        }

       
        // GET: VehicleMakes/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMake = await _makeService.GetMakeById(id);
           
            if (vehicleMake == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            
            try
            {
                await _makeService.DeleteMake(id);
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
            }
            }

        //private bool VehicleMakeExists(int id)
        //{
        //    var vehicleMake = makeService.GetMakeById(id);
            
        //    return _context.VehicleMakes.Any(e => e.Id == id);
        //}
    }
}
