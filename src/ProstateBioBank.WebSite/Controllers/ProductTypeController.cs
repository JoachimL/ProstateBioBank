using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ProstateBioBank.Services;
using ProstateBioBank.ObjectExtensions;
using ProstateBioBank.ServiceModels;

namespace ProstateBioBank.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductStore _productStore;

        public ProductTypeController(IProductStore productStore)
        {
            _productStore = this.GetOrThrowArgumentNullException(productStore, "productStore");
        }


        // GET: /ProductType/
        public async Task<ActionResult> Index()
        {
            return View(await _productStore.GetProductTypesAsync());
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
        public async Task<ActionResult> Create([Bind(Include="Id,Name")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                await _productStore.AddProductTypeAsync(productType);
                return RedirectToAction("Index");
            }

            return View(productType);
        }

        // GET: /ProductType/Edit/5
        public Task<ActionResult> Edit(long? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ProductType producttype = await db.ProductTypes.FindAsync(id);
            //if (producttype == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(producttype);
        }

        // POST: /ProductType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Edit([Bind(Include="Id,Name")] ProductType producttype)
        {
            throw new NotImplementedException();
        }

        // GET: /ProductType/Delete/5
        public Task<ActionResult> Delete(long? id)
        {
            throw new NotImplementedException();
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //ProductType producttype = await db.ProductTypes.FindAsync(id);
            //if (producttype == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(producttype);
        }

        // POST: /ProductType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> DeleteConfirmed(long id)
        {
            throw new NotImplementedException();
            //ProductType producttype = await db.ProductTypes.FindAsync(id);
            //db.ProductTypes.Remove(producttype);
            //await db.SaveChangesAsync();
            //return RedirectToAction("Index");
        }
    }
}
