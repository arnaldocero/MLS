using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MLS.Web.Controllers
{
    public class UserCreated : Controller
    {
        // GET: UserCreated
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserCreated/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserCreated/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserCreated/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCreated/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserCreated/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserCreated/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserCreated/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
