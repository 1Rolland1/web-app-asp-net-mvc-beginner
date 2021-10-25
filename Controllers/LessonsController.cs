using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laba1_Raspisanie_zanyatiy_.Models;

namespace laba1_Raspisanie_zanyatiy_.Controllers
{
    public class LessonsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            RaspisanieContext db = new RaspisanieContext();
            var lessons = db.Lessons.ToList();
            return View(lessons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lesson = new Lesson();

            return View(lesson);
        }

        [HttpPost]
        public ActionResult Create(Lesson model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var db = new RaspisanieContext();

            db.Lessons.Add(model);
            db.SaveChanges();
            

            return RedirectPermanent("/Lessons/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new RaspisanieContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                return RedirectPermanent("/Lessons/Index");

            db.Lessons.Remove(lesson);
            db.SaveChanges();

            return RedirectPermanent("/Lessons/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new RaspisanieContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == id);
            if (lesson == null)
                return RedirectPermanent("/Lessons/Index");

            return View(lesson);
        }

        [HttpPost]
        public ActionResult Edit(Lesson model)
        {
            
            var db = new RaspisanieContext();
            var lesson = db.Lessons.FirstOrDefault(x => x.Id == model.Id);
            if (lesson == null)
            {
                ModelState.AddModelError("Id", "Книга не найдена");
            }
            if (!ModelState.IsValid)
                return View(model);

            MappingLesson(model, lesson);


            db.Entry(lesson).State = EntityState.Modified;
            db.SaveChanges();


            return RedirectPermanent("/Lessons/Index");
        }

        private void MappingLesson (Lesson sourse, Lesson destination)
        {
            destination.LessonName = sourse.LessonName;
            destination.SequentialNumber = sourse.SequentialNumber;
            destination.Teacher = sourse.Teacher;
            destination.Group = sourse.Group;
        }

    }
}