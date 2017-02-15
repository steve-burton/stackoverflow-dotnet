using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StackOverflow.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace StackOverflow.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public ResponsesController (UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(_db.Questions, "Questiond", "Title");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Response response)
        {
            _db.Responses.Add(response);
            _db.SaveChanges();
            return RedirectToAction("Details", "Questions");
        }
    }
}
