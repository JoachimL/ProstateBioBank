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
    public class PatientController : Controller
    {
        private ProstateBioBankContext db = new ProstateBioBankContext();

        // GET: /Patient/
        public async Task<ActionResult> Index()
        {
            return View(await db.Patients.ToListAsync());
        }

        // GET: /Patient/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patient = await db.Patients
                .Include(p => p.Biopsies.Select(b => b.Alequots.Select(a => a.Products)))
                .SingleOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return HttpNotFound();
            }

            Models.PatientDetailsViewModel model = new Models.PatientDetailsViewModel();
            model.PatientId = patient.Id;
            model.Biopsies = patient.Biopsies;
            model.DAmicoScore = patient.DAmicoScore;
            model.DateOfSurgery = patient.DateOfSurgery;
            model.GleasonScore = patient.GleasonScore;
            model.Psa = patient.Psa;
            model.Ptnm = patient.Ptnm;
            model.Tnm = patient.Tnm;
            model.YearOfBirth = patient.YearOfBirth;
            return View(model);
        }

        // GET: /Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Patient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Tnm,Ptnm,Psa,GleasonScore,DAmicoScore,YearOfBirth,DateOfSurgery")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: /Patient/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: /Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Tnm,Ptnm,Psa,GleasonScore,DAmicoScore,YearOfBirth,DateOfSurgery")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: /Patient/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = await db.Patients.FindAsync(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: /Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Patient patient = await db.Patients.FindAsync(id);
            db.Patients.Remove(patient);
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
