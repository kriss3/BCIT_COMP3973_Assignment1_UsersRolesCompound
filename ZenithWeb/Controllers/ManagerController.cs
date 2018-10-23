using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWeb.Data;
using ZenithWeb.Models;

namespace ZenithWeb.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ManagerController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManagerController(ApplicationDbContext _ctx, UserManager<ApplicationUser> _userManager)
        {
            this._ctx = _ctx;
            this._userManager = _userManager;
        }

        // GET: Manager
        public IActionResult Index()
        {
            ViewBag.Title = "Available User List";
            var users = _ctx.Users.ToList();
            var qry = (from u in _ctx.Users
                       join usrRoles in _ctx.UserRoles on u.Id equals usrRoles.UserId
                       select new ApplicationUser()
                       {
                           Id = u.Id,
                           FirstName = u.FirstName,
                           LastName = u.LastName,
                           UserName = u.UserName,
                           Email = u.Email,
                           AppRole = (from x in _ctx.Roles.Where(x => x.Id == usrRoles.RoleId) select x).FirstOrDefault()

                       }).ToList();

            return View(qry);
        }

        // GET: Manager/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
                return NotFound();

            var user = _ctx.Users.Find(id);
            var userRole = _ctx.UserRoles.Where(x => x.UserId == id).Select(r => r).FirstOrDefault();
            var thisUserRole = _ctx.Roles.Where(x => x.Id == userRole.RoleId).Select(r => r).FirstOrDefault();
            user.AppRole = thisUserRole;
            return View(user);
        }


        // GET: Manager/Edit/5
        public ActionResult Edit(string id)
        {
            var user = _ctx.Users.Find(id);
            var userRole = _ctx.UserRoles.Where(x => x.UserId == id).Select(r => r).FirstOrDefault();
            var thisUserRole = _ctx.Roles.Where(x => x.Id == userRole.RoleId).Select(r => r).FirstOrDefault();
            user.AppRole = thisUserRole;
            return View(user);
        }

        // POST: Manager/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id", "FirstName", "LastName", "UserName", "Email", "AppRole", "Street", "City", "Province", "PostalCode", "Country", "AppRole")] ApplicationUser _appUser)
        {
            if (id != _appUser.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUserRole = _ctx.UserRoles.Where(x => x.UserId == _appUser.Id).Select(r => r.RoleId).Single();
                    var oldRoleName = (from u in _ctx.Roles.Where(r => r.Id == currentUserRole) select u.Name).SingleOrDefault();

                    var oldRoleId = _userManager.RemoveFromRoleAsync(_appUser, oldRoleName);

                    await _userManager.AddToRoleAsync(_appUser, _appUser.AppRole.Name);

                    //DbUpdateException is thrown !!! trying to update UserRoles with new ApplicationUser (was Admin, now Member)
                    _ctx.Update(_appUser);
                    _ctx.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    return View(_appUser);
                }
            }
            return View(_appUser);
        }

    }
}