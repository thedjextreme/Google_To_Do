
using Google_To_Do.Models;
using Google_ToDo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_To_Do.Controllers
{
    public class TaskController : Controller
    {

        private readonly Taskcontext _db;
        //private ApplicationDbContext _productManager = new ProductManager();
        //ApplicationDbContext _categorymanager = new CategoryManager();

        public TaskController(Taskcontext db)
        {
            _db = db;

        }


        public IActionResult Index()
        {




            // ViewBag.AssignmentName = TaskName;
            //ViewBag.PrioritySelectList = new SelectList(_db.zadanie, "Id", "Name", null);

            //IEnumerable<zadanie> objList = _db.zadanie;
            //return View(objList);

            var work = _db.zadanie.Where(x => x.IsActive == true).ToList();

            return View(work);
        }
        //get - create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //post -create
        public IActionResult Create(zadanie obj)
        {
            //  List<SelectListItem> cities = new()
            // {
            //  new SelectListItem { Value = "1", Text = "Latur" },
            //  new SelectListItem { Value = "2", Text = "Solapur" },
            //  new SelectListItem { Value = "3", Text = "Nanded" },
            //  new SelectListItem { Value = "4", Text = "Nashik" },
            //  new SelectListItem { Value = "5", Text = "Nagpur" },
            //  new SelectListItem { Value = "6", Text = "Kolhapur" },
            // new SelectListItem { Value = "7", Text = "Pune" },
            //   new SelectListItem { Value = "8", Text = "Mumbai" },
            //   new SelectListItem { Value = "9", Text = "Delhi" },
            //  new SelectListItem { Value = "10", Text = "Noida" }
            //};
            _db.zadanie.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //get - edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.zadanie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(zadanie obj)
        {
            if (ModelState.IsValid)
            {
                _db.zadanie.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            //ViewData["TaskName"] = new SelectList(_db.zadanie, "Id", "TaskName");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.zadanie.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var employee = _db.zadanie.FirstOrDefault(x => x.Id == id);
            //var v = employee.IsActive == false;
            //_db.zadanie.Update(employee);
            //_db.zadanie.Remove(employee);
            // _db.SaveChanges();

            employee.IsActive = false;
            employee.EndDate = DateTime.Now;
            _db.zadanie.Update(employee);

            //await _db.SaveChangesAsync();
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

            //return RedirectToAction(nameof(Index));


            //var obj = _db.zadanie.Find(id);
            /// ViewData["TaskName"] = new SelectList(_db.zadanie, "Id", "TaskName");


            // obj.EndDate = DateTime.Now;
            // if (obj == null)
            // {
            //     return NotFound();
            //}
            //obj.IsActive = false;

            //_db.zadanie.Update(obj);
            //_db.SaveChanges();
            //return RedirectToAction("Index");

        }
    }
}
