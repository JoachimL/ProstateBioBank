using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ProstateBioBank.Models;
using ProstateBioBank.Services;
using ProstateBioBank.ObjectExtensions;
using ProstateBioBank.ServiceModels;

namespace ProstateBioBank.Controllers
{
    public class BiopsyController : Controller
    {
        private readonly IBiopsyStore _biopsyStore;
        private readonly IPatientStore _patientStore;

        public BiopsyController(IPatientStore patientStore, IBiopsyStore biopsyStore)
        {
            _patientStore = this.GetOrThrowArgumentNullException(patientStore, "patientStore");
            _biopsyStore = this.GetOrThrowArgumentNullException(biopsyStore, "biopsyStore");
        }

        // GET: /Biopsy/
        public async Task<ActionResult> Index()
        {
            return View((await _biopsyStore.GetBiopsiesAsync()).Select(BiopsyToIndexModel));
        }

        public BiopsyIndexViewModel BiopsyToIndexModel(Biopsy biopsy)
        {
            return new BiopsyIndexViewModel()
            {
                Id = biopsy.Id,
                PatientId = biopsy.PatientId
            };
        }

        // GET: /Biopsy/Details/5
        public Task<ActionResult> Details(string id)
        {
            throw new NotImplementedException();
        }

        // GET: /Biopsy/Create
        public ActionResult Create()
        {
            var model = new BiopsyCreateModel();
            SetPatientsOnModel(model);
            return View(model);
        }

        private void SetPatientsOnModel(BiopsyCreateModel model)
        {
            model.Patients = (_patientStore.GetPatients()).Select(p => new SelectListItem() { Text = p.Id, Value = p.Id });
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
                    PatientId = biopsyModel.PatientId
                };
                await _biopsyStore.AddBiopsyAsync(biopsy);
                return RedirectToAction("Index");
            }

            SetPatientsOnModel(biopsyModel);
            return View(biopsyModel);
        }

        // GET: /Biopsy/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Biopsy biopsy = await _biopsyStore.GetBiopsyByIdAsync(id);
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
        public Task<ActionResult> Edit([Bind(Include = "Id")] BiopsyEditModel biopsy)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    db.Entry(biopsy).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(biopsy);
        }

        // GET: /Biopsy/Delete/5
        public Task<ActionResult> Delete(string id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Biopsy biopsy = await db.Biopsies.FindAsync(id);
            //if (biopsy == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(biopsy);
        }

        // POST: /Biopsy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _biopsyStore.DeleteBiopsyAsync(id);
            return RedirectToAction("Index");
        }
    }
}
