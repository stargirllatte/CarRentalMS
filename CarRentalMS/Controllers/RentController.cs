using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalMS.Data;
using CarRentalMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalMS.Controllers
{
    [Route("api/[controller]")]
    public class RentController : Controller
    {
        private readonly CarRentalMSContext _context;

        public RentController(CarRentalMSContext context)
        {
            _context = context;
        }

        // GET: Rent
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var rents = await _context.Rent.ToListAsync();
            return View(rents); // Returns the list view of rents
        }

        // GET: Rent/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent); // Returns the details view of a specific rent
        }

        // GET: Rent/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new rent
        }

        // POST: Rent/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rent rent)
        {
            if (ModelState.IsValid)
            {
                // Make sure we are not inserting a value for rent_id (Identity column)
                rent.car_id = 0;  // Explicitly set rent_id to 0 to ensure auto-increment works correctly (if rent_id is an identity column)

                _context.Add(rent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the rents list
            }
            return View(rent);
        }

        // GET: Rent/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }
            return View(rent); // Returns the edit view for a specific rent
        }

        // POST: Rent/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rent rent)
        {
            if (id != rent.car_id)  // Ensure we're editing the right rent record by car_id
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the rents list
            }
            return View(rent);
        }

        // GET: Rent/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            return View(rent); // Returns the delete confirmation view
        }

        // POST: Rent/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent != null)
            {
                _context.Rent.Remove(rent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the rents list
        }

        private bool RentExists(int id)
        {
            return _context.Rent.Any(e => e.car_id == id); // Ensure the rent exists by CarID
        }
    }
}