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
                var today = DateTime.Now.Year;
                var age = today - member.BirthDate.Year;
                if(member.BirthDate > DateOnly.FromDateTime(DateTime.Now))
                {
                    age--;
                }
                member.Age = age;
                _dbcontext.Add(member);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _dbcontext.Members.FindAsync(id);
            if(member == null)
            {
                return NotFound();    
            }
            _dbcontext.Members.Remove(member);
            await _dbcontext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
