using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskRepository _repository;
        private readonly IUserRepository _userRepository;

        /*
* Implement the below mentioned methods as per mentioned requiremetns.
*/

        // Index action method should return view along with all tasks based upon the logged in user


        // Details action method should retrieve tasks data from database based upon the logged in user and id
        // if success, return view with task details else return not found status


        // Create action method should get all categories from database based upon logged in user
        // and return view


        // Create action method should handle post request and store task details in database. 
        // If success redirect to index action method else return view with model


        // Edit action method should retrieve task details from database based upon logged in user and id
        // If success return view along with task details else return not found status

        // Edit action should handle post request and modify the task details into database.
        // If success redirect to index action method else return view with model.


        // Delete action method should retrieve task details from database based upon logged in user and id
        // If success return view with task details else return not found status

        // DeleteConfirmed action method should handle post request. Action name should be given as Delete using attribute.
        // This method should delete task details from database based upon logged in user and id then return to index


        //public TasksController(ITaskRepository repository)
        //{
        //    _repository = repository;
        //    _userRepository = userRepository;
        //}
        public TasksController()
        {
            _repository = new TaskRepository();
            _userRepository = new UserRepository();
        }
        // GET: AllTasks
        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            try
            {
                var getAllTasks = _repository.GetAllTasks(currentUserName);
                //ViewBag.ListItem = ObjItem;
                return View(getAllTasks);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Tasks/GetTaskById/5
        public ActionResult GetTaskById(string emailid, int? id)
        {

            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                var getTaskById = _repository.GetTaskById(emailid, id);
                if (getTaskById == null)
                {
                    return HttpNotFound();
                }
                return View(getTaskById);
            }
            catch (Exception)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            var currentUserName = User.Identity.Name;
            List<Category> categories = this._userRepository.GetCategoriesForUser(currentUserName);
            var model = new TaskViewModel();
            model.Catogories = categories;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserTask userTask)
        {
            var currentUserName = User.Identity.Name;
            string UserId = this._userRepository.GetUserIdByEmail(currentUserName);
            userTask.UserID = UserId;
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _repository.SaveTask(userTask);
                    //return View(postId);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Delete(int? id)
        {
            var currentUserEmail = User.Identity.Name;
            if (id == null)
            {
                return HttpNotFound();
            }

            var post = _repository.GetTaskById(currentUserEmail, id);
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
            emailid = User.Identity.Name;
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                result = _repository.DeleteTask(emailid, id);
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

        public ActionResult Edit(int? id)
        {
            var currentUserName = User.Identity.Name;
            List<Category> categories = this._userRepository.GetCategoriesForUser(currentUserName);
            var model = new TaskViewModel();
            model.Catogories = categories;

            var currentUserEmail = User.Identity.Name;
            if (id == null)
            {
                return HttpNotFound();
            }

            var post = _repository.GetTaskById(currentUserEmail, id);
            if (post == null)
            {
                return HttpNotFound();
            }

            model.TaskId = post.TaskId;
            model.TaskContent = post.TaskContent;
            model.TaskStatus = post.TaskStatus;
            model.TaskTitle = post.TaskTitle;
            model.CategoryID = post.CategoryID;


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserTask userTask)
        {
            var currentUserName = User.Identity.Name;
            string UserId = this._userRepository.GetUserIdByEmail(currentUserName);
            userTask.UserID = UserId;
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = _repository.UpdateTask(userTask);

                    //return View(postId);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        public ActionResult Details(int? id)
        {
            var currentUserEmail = User.Identity.Name;
            if (id == null)
            {
                return HttpNotFound();
            }

            var post = _repository.GetTaskById(currentUserEmail, id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}