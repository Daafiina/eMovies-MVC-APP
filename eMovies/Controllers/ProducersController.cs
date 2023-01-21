using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eMovies.Data;
using eMovies.Models;
using eMovies.Data.Services;

namespace eMovies.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }


        //Get: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");

            return View(producerDetails);
        }

        //Get: producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,fullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: producers/edit/1
        public async Task <IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,fullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if(id == producer.Id)
            {
                await _service.UpdateAsync(id,producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }

        //Get: producers/delet/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");
            return View();
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


/*// GET: Producers
public async Task<IActionResult> Index()
{
    return View(await _service.Producers.ToListAsync());
}

// GET: Producers/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var producer = await _context.Producers
        .FirstOrDefaultAsync(m => m.Id == id);
    if (producer == null)
    {
        return NotFound();
    }

    return View(producer);
}

// GET: Producers/Create
public IActionResult Create()
{
    return View();
}

// POST: Producers/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
{
    if (ModelState.IsValid)
    {
        _context.Add(producer);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(producer);
}

// GET: Producers/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var producer = await _context.Producers.FindAsync(id);
    if (producer == null)
    {
        return NotFound();
    }
    return View(producer);
}

// POST: Producers/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
{
    if (id != producer.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(producer);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProducerExists(producer.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(producer);
}

// GET: Producers/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var producer = await _context.Producers
        .FirstOrDefaultAsync(m => m.Id == id);
    if (producer == null)
    {
        return NotFound();
    }

    return View(producer);
}

// POST: Producers/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var producer = await _context.Producers.FindAsync(id);
    _context.Producers.Remove(producer);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool ProducerExists(int id)
{
    return _context.Producers.Any(e => e.Id == id);
}
}
}
 */