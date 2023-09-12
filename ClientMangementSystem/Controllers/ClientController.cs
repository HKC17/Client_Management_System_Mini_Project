using ClientMangementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientMangementSystem.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        public ActionResult Index()
        {
            List<Client> lst = Client.GetAllClient();
            return View(lst);
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
                return NotFound();
            Client obj = Client.GetSingleClient(id.Value);
            return View(obj);
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client obj)
        {
            try
            {
                Client.InsertClient(obj);
                ViewBag.message = "Success!";
                return View();
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Client obj = Client.GetSingleClient(id.Value);
            return View(obj);
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client obj)
        {
            try
            {
                Client.UpdateClient(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Client obj = Client.GetSingleClient(id.Value);
            return View(obj);
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client obj)
        {
            try
            {
                Client.DeleteClient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
