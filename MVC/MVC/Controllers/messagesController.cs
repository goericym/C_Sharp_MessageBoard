using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class messagesController : Controller
    {
        private MessageBoardEntities1 db = new MessageBoardEntities1();

        // GET: messages

        public ActionResult Index()
        {
            Data GetData = new Data();
            GetData.Account = "1234";
            GetData.message = db.message.ToList();
            return View(GetData);
        }
        public ActionResult JSON()
        {
            return Json(db.message, JsonRequestBehavior.AllowGet);
        }

        // GET: messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: messages/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Message1,Account,UpdateTime")] message message)
        {
            if (ModelState.IsValid)
            {
                message.UpdateTime = DateTime.Now;
                db.message.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: messages/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Message1,Account,UpdateTime")] message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            message message = db.message.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            message message = db.message.Find(id);
            db.message.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult GetAll()
        {
            Data GetData = new Data();
            GetData.Account = "1234";
            GetData.message = db.message.ToList();
            GetData.remessage = db.ReMessage.ToList();
            return View(GetData);
        }
        [HttpPost, ActionName("CreateReMsg")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateReMsg([Bind(Include = "ID,Re_Id,Account,Message,UpdateTime")] ReMessage reMessage)
        {
            if (ModelState.IsValid)
            {
                reMessage.UpdateTime = DateTime.Now;
                reMessage.Account = "asdf";
                db.ReMessage.Add(reMessage);
                await db.SaveChangesAsync();
                //return RedirectToAction("Index");
                return View(reMessage);
            }

            //return View(reMessage);
            return Content("");
        }
    }
}
