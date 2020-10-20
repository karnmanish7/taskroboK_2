using System;
using System.Net;
using System.Web.Mvc;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{

    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _repository;
        private readonly IUserRepository _userRepository;

        /*
* Implement the below mentioned methods as per mentioned requiremetns.
*/

        // Index action method should return view along with all categories based on logged in user.

        // Create action method should return view

        // Create action method should handle the post request and save category details in database. If success, redirect to index action method
        // else return view with model


        // Delete action method should return details view with category details
        // else return not found status

        // Delete action method should handle post request and delete category from database based upon category id and redirect to index


        //public CategoriesController(ICategoryRepository repository, IUserRepository userRepository)
        //{
        //    _repository = repository;
        //    _userRepository = userRepository;
        //}
        public CategoriesController()
        {
            _repository = new CategoryRepository();
            _userRepository = new UserRepository();
        }
        // GET: AllCategories
        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            try
            {
                var getAllCategories = _repository.GetAllCategories(currentUserName);
                //if (getAllCategories.Count == 0)
                //{
                //    return HttpNotFound();
                //}
                return View(getAllCategories);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Category/GetCategoryById/5
        public ActionResult GetCategoryById(int? id)
        {

            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var getCategoryById = _repository.GetCategoryById(id);
                if (getCategoryById == null)
                {
                    return HttpNotFound();
                }
                return View(getCategoryById);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Category category)
        {

            var currentUserName = User.Identity.Name;
            string UserId = this._userRepository.GetUserIdByEmail(currentUserName);
            category.UserID = UserId;
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _repository.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            var currentUserEmail = User.Identity.Name;
            if (id == null)
            {
                return HttpNotFound();
            }

            var post = _repository.GetCategoryById(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [HttpPost]
        public ActionResult Delete(string emailid, int? id)
        {
            int result = 0;
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                result = _repository.DeleteCategory(id);
                if (result == 0)
                {
                    return HttpNotFound();
                }
                //return View(result);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
