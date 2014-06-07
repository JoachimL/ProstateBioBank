using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProstateBioBank.ServiceModels;
using ProstateBioBank.Services;
using ProstateBioBank.ObjectExtensions;

namespace ProstateBioBank.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientStore _patientStore;

        public PatientController(IPatientStore patientStore)
        {
            _patientStore = this.GetOrThrowArgumentNullException(patientStore, "patientStore");
        }


        // GET: /Patient/
        public async Task<ActionResult> Index()
        {
            return View(await _patientStore.GetPatientsAsync());
        }

        // GET: /Patient/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var patient = await _patientStore.GetPatientByIdAsync(id);
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
                await _patientStore.AddPatientAsync(patient);
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: /Patient/Edit/5
        public Task<ActionResult> Edit(string id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Patient patient = await db.Patients.FindAsync(id);
            //if (patient == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(patient);
        }

        // POST: /Patient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Edit([Bind(Include = "Id,Tnm,Ptnm,Psa,GleasonScore,DAmicoScore,YearOfBirth,DateOfSurgery")] Patient patient)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    db.Entry(patient).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(patient);
        }

        // GET: /Patient/Delete/5
        public Task<ActionResult> Delete(string id)
        {
            throw new NotImplementedException();
        }

        // POST: /Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> DeleteConfirmed(string id)
        {
            throw new NotImplementedException();
        }

    }
}
