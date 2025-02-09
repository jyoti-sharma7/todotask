using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodotaskWeb.Data;
using TodotaskWeb.Models.ViewModels;
using TodotaskWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace TodotaskWeb.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<User> _userManager;
        public NoteController(ApplicationDbContext db, UserManager<User> userManager)/*  application db context inject garna ko lagi ctor use*/
        {
            _userManager = userManager;
            _db = db;
        }
        //note/index   //note
        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var notes = _db.Notes.Where(n => n.UserId == userId).ToList();
            return View(notes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new NoteViewModel());
        }
        [HttpPost]
        public IActionResult Create(NoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                var note = new Note()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Color = model.Color,
                    UserId = userId
                };
                _db.Notes.Add(note);
                _db.SaveChanges();
                TempData["success"] = "Record created successfully";
                return RedirectToAction("Index", "Note");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var note = _db.Notes.FirstOrDefault(n => n.Id == id);
            if(note.UserId == userId)
            {
                var model = new NoteViewModel()
                {
                    Id = note.Id,
                    Title = note.Title,
                    Description = note.Description,
                    CreatedDate = note.CreatedDate,
                    UserId = userId,
                    Color = note.Color
                };
                return View(model);
            }
            else
            {
                return Content("You are not authorized");
            }
          
        }
        [HttpPost]
        public IActionResult Edit(NoteViewModel model)
        {
            if (ModelState.IsValid) {
                var userId = _userManager.GetUserId(HttpContext.User);
                if (model.UserId == userId)
                {
                    var note = new Note
                    {
                        Id = model.Id,
                        Title = model.Title,
                        Description = model.Description,
                        CreatedDate = model.CreatedDate,
                        UserId =model.UserId,
                        Color = model.Color

                    };
                    _db.Notes.Update(note);
                    _db.SaveChanges();
                    TempData["success"] = "Record Updated successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return Content("You are not authorized");
                }
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return Content("Id is null");
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            var note = _db.Notes.FirstOrDefault(n => n.Id == id);
            if(note.UserId == userId)
            {
                _db.Notes.Remove(note);
                _db.SaveChanges();
                TempData["error"] = "Record Deleted successfully";
                return RedirectToAction("Index");
            }
            return Content("You are not authorized");
        }
    }
}
