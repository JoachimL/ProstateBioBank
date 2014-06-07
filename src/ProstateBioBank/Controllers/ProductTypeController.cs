using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProstateBioBank.Domain;

namespace ProstateBioBank.Controllers
{
    public class ProductTypeController : Controller
    {
        private ProstateBioBankContext db = new ProstateBioBankContext();

        // GET: /ProductType/
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductTypes.ToListAsync());
        }

        // GET: /ProductType/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = await db.ProductTypes.FindAsync(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // GET: /ProductType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ProductType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.ProductTypes.Add(producttype);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(producttype);
        }

        // GET: /ProductType/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = await db.ProductTypes.FindAsync(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /ProductType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name")] ProductType producttype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producttype).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(producttype);
        }

        // GET: /ProductType/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductType producttype = await db.ProductTypes.FindAsync(id);
            if (producttype == null)
            {
                return HttpNotFound();
            }
            return View(producttype);
        }

        // POST: /ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ProductType producttype = await db.ProductTypes.FindAsync(id);
            db.ProductTypes.Remove(producttype);
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
