using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using news.Models;
using System.Diagnostics;

namespace news.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsDBContext db;
        public NewsController(NewsDBContext context)
        {
            db = context;
        }
        

        public IActionResult Index()
        {
            List<NewsModel> newsList = db.News.ToList();
            return View(newsList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NewsModel news)
        {
            if(ModelState.IsValid)
            {
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }
        public ActionResult Edit(int id)
        {
            NewsModel news = db.News.Find(id);
            return View(news);
        }
        [HttpPost]
        public ActionResult Edit(NewsModel news)
        {
            if(ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(news);
        }
        public ActionResult Delete(int id)
        {
            NewsModel news = db.News.Find(id);
            return View(news);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModel news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}