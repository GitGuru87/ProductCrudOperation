using Microsoft.AspNetCore.Mvc;
using ProductCrudOperation.DataAccess;
using ProductCrudOperation.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace ProductCrudOperation.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(IConfiguration configuration)
        {
            _repository = new ProductRepository(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repository.GetAllProducts();
            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repository.GetProductById(id);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = await _repository.GetProductById(product.Id);

                
                if (existingProduct != null &&
                    (existingProduct.Name != product.Name ||
                     existingProduct.Description != product.Description ||
                     existingProduct.Price != product.Price ||
                     existingProduct.CreatedDate != product.CreatedDate))
                {
                    await _repository.UpdateProduct(product);
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "No changes were made to the product." });
                }
            }

            
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = string.Join(", ", errors) });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repository.GetProductById(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _repository.DeleteProduct(id); 
                return Json(new { success = true }); 
            }
            catch (Exception ex)
            {
                
                ModelState.AddModelError("", "Unable to delete product. Please try again.");
                return Json(new { success = false, message = ex.Message }); // Return error message
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Return a 404 error if the product is not found
            }
            return View(product); // Pass the product to the view
        }

    }
}
