using Microsoft.AspNetCore.Mvc;
using WebStore.DataAccess.Repository.IRepository;
using WebStore.Models;

namespace WebStoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; 
        public ProductController(IUnitOfWork unitOfWork)  
        {
            _unitOfWork = unitOfWork;
        }
        //[HttpGet] Default
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList(); 
            return View(objProductList);  
        }
        public IActionResult Create()  
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            

            if (ModelState.IsValid) 
            {
                _unitOfWork.Product.Add(obj); 
                _unitOfWork.Save();
                TempData["success"] = "Product successfully created ";
                return RedirectToAction("Index");
            }
            return View();
            
        }


        public IActionResult Edit(int? id)  
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);  
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {


            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product successfully updated";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);  
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id) 
        {


            if (ModelState.IsValid)
            {
                Product obj = _unitOfWork.Product.Get(u => u.Id == id); 
                if (obj == null)
                {
                    return NotFound();
                }
                _unitOfWork.Product.Remove(obj); 
                _unitOfWork.Save();
                TempData["success"] = "Product successfully deleted ";
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}

