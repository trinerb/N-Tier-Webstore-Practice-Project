using Microsoft.AspNetCore.Mvc;
using WebStoreApp.Data;
using WebStoreApp.Models;

namespace WebStoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)    //we want an implementation of the applicationDbContext
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); //we use List<Category> as datatype instead of var to be explicit. else its var objCategoryList. 
            return View(objCategoryList);
        }
        public IActionResult Create()  //returntype: IActionResult. View must match actionmethod (Create)
        {

            return View(); //can pass new Category, but dont have to. makes by default when using @model Category in view with empty values.
        }

        [HttpPost]
        public IActionResult Create(Category obj) 
        {
            if (obj.Name == obj.DisplayOrder.ToString()) //custom errormessages. Here if name matches displayorder. 
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the name.");
            }
            /* if (obj.Name.ToLower() == "test") 
             {
                 ModelState.AddModelError("Name", "Test is an invalid value");
             }*/

            if (ModelState.IsValid) //sjekker om model blir oppfylt. (med f.eks character restriction eller range etc)
            {
                _db.Categories.Add(obj); //telling to add this category object to the category table in db
                _db.SaveChanges(); //actually create the table
                return RedirectToAction("Index");
            }
            return View();
             //kan skrive ("Index", "navn på controller")hvis er i en annen controller
        }


        public IActionResult Edit(int? id)  // ? means nullable
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //different ways of retrieving given category
            Category? categoryFromDb = _db.Categories.Find(id); //will automatically find the id and assign that to categoryFromDb. Only works for primary key.
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id); //will try to find out whether any record. if not write null object and assign. Does not need to be primary key. can use for name or name.contains.
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); 

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);  //return category to view and display it
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the name.");
            }

            if (ModelState.IsValid) 
            {
                _db.Categories.Add(obj); 
                _db.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View();
        
        }

    }
}
