using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProstateBioBank.Models;
using ProstateBioBank.ServiceModels;
using ProstateBioBank.Services;
using ProstateBioBank.ObjectExtensions;

namespace ProstateBioBank.Controllers
{
    public class AlequotController : Controller
    {
        private readonly IBiopsyStore _biopsyStore;

        public AlequotController(IBiopsyStore biopsyStore)
        {
            _biopsyStore = this.GetOrThrowArgumentNullException(biopsyStore, "biopsyStore");
        }

        // GET: /Alequot/
        public async Task<ActionResult> Index()
        {
            return View((await _biopsyStore.GetAlequotsAsync()).Select(a => new AlequotIndexViewModel()
            {
                Id = a.Id,
                BiopsyId = a.BiopsyId,
                PatientId = a.PatientId
            }));
        }

        // GET: /Alequot/Details/5
        public Task<ActionResult> Details(string id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Alequot alequot = await db.Alequots.FindAsync(id);
            //if (alequot == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(alequot);
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
            model.Biopsies = (await _biopsyStore.GetBiopsiesAsync()).Select(BiopsyToSelectListItem);
        }

        private SelectListItem BiopsyToSelectListItem(Biopsy biopsy)
        {
            return new SelectListItem() { Value = biopsy.Id, Text = biopsy.Id + (biopsy.PatientId ?? string.Empty) };
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
                    BiopsyId = alequotModel.BiopsyId,
                    Id = alequotModel.Id
                };
                await _biopsyStore.AddAlequotAsync(alequot);
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
            Alequot alequot = await _biopsyStore.GetAlequotByIdAsync(id);
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
        public Task<ActionResult> Edit([Bind(Include = "Id")] Alequot alequot)
        {
            throw new NotImplementedException();
            //if (ModelState.IsValid)
            //{
            //    db.Entry(alequot).State = EntityState.Modified;
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(alequot);
        }

        // GET: /Alequot/Delete/5
        public Task<ActionResult> Delete(string id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Alequot alequot = await db.Alequots.FindAsync(id);
            //if (alequot == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(alequot);
        }

        // POST: /Alequot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> DeleteConfirmed(string id)
        {
            throw new NotImplementedException();
        }

    }
}
