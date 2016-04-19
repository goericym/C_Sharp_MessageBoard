using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ReMessagesController : Controller
    {
        private MessageBoardEntities1 db = new MessageBoardEntities1();

        // GET: ReMessages
        public async Task<ActionResult> Index()
        {
            return View(await db.ReMessage.ToListAsync());
        }

        // GET: ReMessages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReMessage reMessage = await db.ReMessage.FindAsync(id);
            if (reMessage == null)
            {
                return HttpNotFound();
            }
            return View(reMessage);
        }

        // GET: ReMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReMessages/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Re_Id,Account,Message,UpdateTime")] ReMessage reMessage)
        {
            if (ModelState.IsValid)
            {
                db.ReMessage.Add(reMessage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reMessage);
        }

        // GET: ReMessages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReMessage reMessage = await db.ReMessage.FindAsync(id);
            if (reMessage == null)
            {
                return HttpNotFound();
            }
            return View(reMessage);
        }

        // POST: ReMessages/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Re_Id,Account,Message,UpdateTime")] ReMessage reMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reMessage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reMessage);
        }

        // GET: ReMessages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReMessage reMessage = await db.ReMessage.FindAsync(id);
            if (reMessage == null)
            {
                return HttpNotFound();
            }
            return View(reMessage);
        }

        // POST: ReMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ReMessage reMessage = await db.ReMessage.FindAsync(id);
            db.ReMessage.Remove(reMessage);
            await db.SaveChangesAsync();
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
    }
}
