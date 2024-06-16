using DatavidCakeTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatavidCakeTracker.Models;

namespace DatavidCakeTracker.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly AppDbContext _dbcontext;

        public MemberController(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var members = await _dbcontext.Members.ToListAsync();
            return View(members);
        }

        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create(Member member)
        {
            if(ModelState.IsValid)
            {
                _dbcontext.Add(member);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}
