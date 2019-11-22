using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using n_hashimotoStudy.Data;
using n_hashimotoStudy.Models;

namespace n_hashimotoStudy.Controllers
{
    public class ApplicationUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public ApplicationUsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="context"></param>
        // GET: ApplicationUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationUsers.Include(x => x.Busho).Include(x => x.Role).ToListAsync());
        }

        // GET: ApplicationUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.ApplicationUsers
                .Include(x => x.Busho).Include(x => x.Role)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // GET: ApplicationUsers/Create
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

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SyainName,No,Email, BushoId, RoleId")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = applicationUser.Email,
                    Email = applicationUser.Email,
                    No = applicationUser.No,
                    SyainName = applicationUser.SyainName
                };

                // ASP.Net.Identityのユーザー登録機構を利用する
                var result = await _userManager.CreateAsync(user, applicationUser.No); // 初期パスワードは社員番号

                if (!result.Succeeded)
                {
                    Exception ex = new Exception(result.Errors.ToString());
                    // LoggingExtension.WriteExceptionLog(ex);
                    throw ex;
                }

                user.Busho = _context.Bushoes.SingleOrDefault(p => p.Id == applicationUser.BushoId);
                user.Role = _context.Roles.SingleOrDefault(p => p.Id == applicationUser.RoleId);
                _context.Update(user);

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


            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var ApplicationUser = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
            var ApplicationUser = await _context.ApplicationUsers.Where(m => m.Id == id).Include(m => m.Busho).Include(m => m.Role).SingleOrDefaultAsync();
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            // 部署リスト
            var sections = _context.Bushoes
                .Select(x => new { Id = x.Id, Value = x.BushoName });
            ViewBag.BushoList = new SelectList(sections, "Id", "Value");

            // 権限リスト
            var kengens = _context.Roles
                .Select(x => new { Id = x.Id, Value = x.RoleName });
            ViewBag.RoleList = new SelectList(kengens, "Id", "Value");

            return View(ApplicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,SyainName,No,Email, BushoId, RoleId")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var user = _context.ApplicationUsers.Where(t => t.Id == applicationUser.Id).FirstOrDefault();
                    user.UserName = applicationUser.Email;
                    user.Email = applicationUser.Email;
                    user.No = applicationUser.No;
                    user.SyainName = applicationUser.SyainName;
                    user.Busho = _context.Bushoes.SingleOrDefault(p => p.Id == applicationUser.BushoId);
                    user.Role = _context.Roles.SingleOrDefault(p => p.Id == applicationUser.RoleId);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
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

            // 部署リスト
            var sections = _context.Bushoes
                .Select(x => new { Id = x.Id, Value = x.BushoName });
            ViewBag.BushoList = new SelectList(sections, "Id", "Value");

            // 権限リスト
            var kengens = _context.Roles
                .Select(x => new { Id = x.Id, Value = x.RoleName });
            ViewBag.RoleList = new SelectList(kengens, "Id", "Value");

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.ApplicationUsers
                .Where(m => m.Id == id).Include(m => m.Busho).Include(m => m.Role)
                .SingleOrDefaultAsync();
            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var syain = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApplicationUsers.Remove(syain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}
