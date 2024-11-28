using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalMS.Data;
using CarRentalMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalMS.Controllers
{
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly CarRentalMSContext _context;

        public CarsController(CarRentalMSContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await _context.Cars.ToListAsync();
            return View(cars); // Returns the list view of cars
        }

        // GET: Students/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Cars.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student); // Returns the details view of a specific student
        }

        // GET: Students/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(); // Returns the view for creating a new student
        }

        // POST: Students/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cars student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(student);
        }

        // GET: Students/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _context.Cars.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student); // Returns the edit view for a specific student
        }

        // POST: Students/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cars cars)
        {
            if (id != cars.car_id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index)); // Redirects to the student list
            }
            return View(cars);
        }

        // GET: Students/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars); // Returns the delete confirmation view
        }

        // POST: Students/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Cars.FindAsync(id);
            if (student != null)
            {
                _context.Cars.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index)); // Redirects to the student list
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.car_id == id);
        }
    }
}