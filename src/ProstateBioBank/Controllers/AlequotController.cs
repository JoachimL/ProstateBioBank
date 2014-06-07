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
using ProstateBioBank.Models;

namespace ProstateBioBank.Controllers
{
    public class AlequotController : Controller
    {
        private ProstateBioBankContext db = new ProstateBioBankContext();

        // GET: /Alequot/
        public async Task<ActionResult> Index()
        {
            return View((await db.Alequots.ToListAsync()).Select(a => new AlequotIndexViewModel()
            {
                Id = a.Id,
                BiopsyId = a.Biopsy.Id,
                PatientId = a.Biopsy.Patient.Id
            }));
        }

        // GET: /Alequot/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alequot alequot = await db.Alequots.FindAsync(id);
            if (alequot == null)
            {
                return HttpNotFound();
            }
            return View(alequot);
        }

        // GET: /Alequot/Create
        public async Task<ActionResult> Create()
        {
            var model = new AlequotCreateModel();
            await SetBiopsyOnModel(model);
            return View(model);
        }

        private async Task SetBiopsyOnModel(AlequotCreateModel model)
        {
            model.Biopsies = (await db.Biopsies.ToListAsync()).Select(BiopsyToSelectListItem);
        }

        private SelectListItem BiopsyToSelectListItem(Biopsy biopsy)
        {
            return new SelectListItem() { Value = biopsy.Id, Text = biopsy.Id + (biopsy.Patient == null ? string.Empty : " (" + biopsy.Patient.Id + ")") };
        }

        // POST: /Alequot/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BiopsyId")] AlequotCreateModel alequotModel)
        {
            if (ModelState.IsValid)
            {
                var alequot = new Alequot()
                {
                    Biopsy = db.Biopsies.Single(b => b.Id == alequotModel.BiopsyId),
                    Id = alequotModel.Id
                };
                db.Alequots.Add(alequot);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            await SetBiopsyOnModel(alequotModel);
            return View(alequotModel);
        }

        // GET: /Alequot/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alequot alequot = await db.Alequots.FindAsync(id);
            if (alequot == null)
            {
                return HttpNotFound();
            }
            return View(alequot);
        }

        // POST: /Alequot/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Alequot alequot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alequot).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(alequot);
        }

        // GET: /Alequot/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alequot alequot = await db.Alequots.FindAsync(id);
            if (alequot == null)
            {
                return HttpNotFound();
            }
            return View(alequot);
        }

        // POST: /Alequot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Alequot alequot = await db.Alequots.FindAsync(id);
            db.Alequots.Remove(alequot);
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
