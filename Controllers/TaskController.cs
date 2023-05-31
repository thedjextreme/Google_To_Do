
using Google_To_Do.Models;
using Google_ToDo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_To_Do.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {

        private readonly Taskcontext _db;


        public TaskController(Taskcontext db)
        {
            _db = db;

        }


        public IActionResult Index()
        {


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
          

            employee.IsActive = false;
            employee.EndDate = DateTime.Now;
            _db.zadanie.Update(employee);

            
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
    }
}
