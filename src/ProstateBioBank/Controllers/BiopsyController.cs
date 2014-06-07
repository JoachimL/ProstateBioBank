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
    public class BiopsyController : Controller
    {
        private ProstateBioBankContext db = new ProstateBioBankContext();

        // GET: /Biopsy/
        public async Task<ActionResult> Index()
        {
            return View((await db.Biopsies.ToListAsync()).Select(BiopsyToIndexModel));
        }

        public BiopsyIndexViewModel BiopsyToIndexModel(Biopsy biopsy)
        {
            return new BiopsyIndexViewModel()
            {
                Id = biopsy.Id,
                PatientId = (biopsy.Patient == null) ? string.Empty : biopsy.Patient.Id
            };
        }

        // GET: /Biopsy/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = await db.Biopsies.FindAsync(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // GET: /Biopsy/Create
        public async Task<ActionResult> Create()
        {
            var model = new BiopsyCreateModel();
            await SetPatientsOnModel(model);
            return View(model);
        }

        private async Task SetPatientsOnModel(BiopsyCreateModel model)
        {
            model.Patients = (await db.Patients.ToListAsync()).Select(p => new SelectListItem() { Text = p.Id, Value = p.Id });
        }

        // POST: /Biopsy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PatientId")] BiopsyCreateModel biopsyModel)
        {
            if (ModelState.IsValid)
            {
                var biopsy = new Biopsy()
                {
                    Id = biopsyModel.Id,
                    Patient = db.Patients.Single(p => p.Id == biopsyModel.PatientId)
                };
                db.Biopsies.Add(biopsy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            await SetPatientsOnModel(biopsyModel);
            return View(biopsyModel);
        }

        // GET: /Biopsy/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = await db.Biopsies.FindAsync(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // POST: /Biopsy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id")] Biopsy biopsy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(biopsy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(biopsy);
        }

        // GET: /Biopsy/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = await db.Biopsies.FindAsync(id);
            if (biopsy == null)
            {
                return HttpNotFound();
            }
            return View(biopsy);
        }

        // POST: /Biopsy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Biopsy biopsy = await db.Biopsies.FindAsync(id);
            db.Biopsies.Remove(biopsy);
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
