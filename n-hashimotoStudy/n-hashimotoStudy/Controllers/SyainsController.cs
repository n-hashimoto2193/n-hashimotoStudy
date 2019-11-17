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
    public class SyainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SyainsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Syains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Syains.Include(x => x.Busho).Include(x => x.Role).ToListAsync());
        }

        // GET: Syains/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syain = await _context.Syains
                .SingleOrDefaultAsync(m => m.Id == id);
            if (syain == null)
            {
                return NotFound();
            }

            return View(syain);
        }

        // GET: Syains/Create
        public IActionResult Create()
        {
            // 部署リスト
            var sections = _context.Bushoes
                .Select(x => new { Id = x.Id, Value = x.BushoName });
            ViewBag.BushoList = new SelectList(sections, "Id", "Value");

            // 権限リスト
            var kengens = _context.Roles
                .Select(x => new { Id = x.Id, Value = x.RoleName });
            ViewBag.RoleList = new SelectList(kengens, "Id", "Value");

            return View();
        }

        // POST: Syains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SyainName,No,Email, BushoId, RoleId")] Syain syain)
        {
            if (ModelState.IsValid)
            {
                syain.Busho = _context.Bushoes.Find(syain.BushoId);
                syain.Role = _context.Roles.Find(syain.RoleId);

                _context.Add(syain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // 部署リスト
            var sections = _context.Bushoes
                .Select(x => new { Id = x.Id, Value = x.BushoName });
            ViewBag.BushoList = new SelectList(sections, "Id", "Value");

            // 権限リスト
            var kengens = _context.Roles
                .Select(x => new { Id = x.Id, Value = x.RoleName });
            ViewBag.RoleList = new SelectList(kengens, "Id", "Value");


            return View(syain);
        }

        // GET: Syains/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syain = await _context.Syains.SingleOrDefaultAsync(m => m.Id == id);
            if (syain == null)
            {
                return NotFound();
            }
            return View(syain);
        }

        // POST: Syains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,SyainName,No,Email")] Syain syain)
        {
            if (id != syain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(syain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SyainExists(syain.Id))
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
            return View(syain);
        }

        // GET: Syains/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syain = await _context.Syains
                .SingleOrDefaultAsync(m => m.Id == id);
            if (syain == null)
            {
                return NotFound();
            }

            return View(syain);
        }

        // POST: Syains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var syain = await _context.Syains.SingleOrDefaultAsync(m => m.Id == id);
            _context.Syains.Remove(syain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyainExists(long id)
        {
            return _context.Syains.Any(e => e.Id == id);
        }
    }
}
