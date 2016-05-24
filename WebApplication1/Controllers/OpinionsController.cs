using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Queries;

namespace WebApplication1.Controllers
{
    public class OpinionsController : Controller
    {

        WebAppDB _db = new WebAppDB();

        // GET: Opinions
        public ActionResult Opinions()
        {
            var model = _db.Reviews;
            return View(model);
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.FindById(id);
            return View(review);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _db.Reviews.FindById(id);

            if (TryUpdateModel(review))
            {
                _db.SaveChanges();
                return RedirectToAction("Opinions");
            }

            return View(review);
        }
    }
}