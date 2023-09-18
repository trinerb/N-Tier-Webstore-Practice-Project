using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.DataAccess.Data;

namespace WebStoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)    //we want an implementation of the applicationDbContext
        {
            _db = db;
        }
        //[HttpGet] Default
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
                TempData["success"] = "Category successfully created "; //can now display message on desired view. In this case, Index. 
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
            Category? categoryFromDb = _db.Categories.Find(id); //Must have ID. will automatically find the id and assign that to categoryFromDb. Only works for primary key.
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id); //Doesn't necessarily need ID. will try to find out whether any record. if not write null object and assign. Does not need to be primary key. can use for name or name.contains.
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault(); 

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);  //return category to view and display it(in the text fields)
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            

            if (ModelState.IsValid) 
            {
                _db.Categories.Update(obj); //will update based on id (built-in). entity framework use .Update
                _db.SaveChanges();
                TempData["success"] = "Category successfully updated";
                return RedirectToAction("Index");
            }
            return View();
        
        }

        public IActionResult Delete(int? id)  // ? means nullable
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            
            Category? categoryFromDb = _db.Categories.Find(id); 

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);  //return category to view and display it(in the text fields)
        }

        [HttpPost, ActionName("Delete")]//we have to rename to DeletePOST to not be duplicate function. But can set actionName to have same endpoint/Delete
        public IActionResult DeletePOST(int? id) //can get entire category obj(Category obj) or just the id the user wants to delete
        {  


            if (ModelState.IsValid)
            {
                Category obj = _db.Categories.Find(id); //find the selected category in database
                if (obj == null)
                {
                    return NotFound();
                }
                _db.Categories.Remove(obj); //remove object retrieved from the database
                _db.SaveChanges();
                TempData["success"] = "Category successfully deleted ";
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
