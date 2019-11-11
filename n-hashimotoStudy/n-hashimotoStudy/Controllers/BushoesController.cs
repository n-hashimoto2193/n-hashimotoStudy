using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;

namespace n_hashimotoStudy.Controllers
{
    public class BushoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BushoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bushoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bushoes.ToListAsync());
        }

        // GET: Bushoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busho = await _context.Bushoes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (busho == null)
            {
                return NotFound();
            }

            return View(busho);
        }

        // GET: Bushoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bushoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BushoName")] Busho busho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(busho);
        }

        // GET: Bushoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busho = await _context.Bushoes.SingleOrDefaultAsync(m => m.Id == id);
            if (busho == null)
            {
                return NotFound();
            }
            return View(busho);
        }

        // POST: Bushoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,BushoName")] Busho busho)
        {
            if (id != busho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BushoExists(busho.Id))
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
            return View(busho);
        }

        // GET: Bushoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busho = await _context.Bushoes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (busho == null)
            {
                return NotFound();
            }

            return View(busho);
        }

        // POST: Bushoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var busho = await _context.Bushoes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Bushoes.Remove(busho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BushoExists(long id)
        {
            return _context.Bushoes.Any(e => e.Id == id);
        }
    }
}
