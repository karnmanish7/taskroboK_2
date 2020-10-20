using System.Web.Mvc;
using System.Web.Security;
using TaskRobo.Models;
using TaskRobo.Repository;

namespace TaskRobo.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository _useRrepository;

        //public AccountController(IUserRepository useRrepository)
        //{
        //    _useRrepository = useRrepository;
        //}

        public AccountController()
        {
            _useRrepository = new UserRepository();
        }


        // Register action method should return view
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        // Register action method should handle post request and register the user details in database
        // user should be redirected to Tasks list view after successfull registration

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            AppUser appUser = new AppUser();
            appUser.Email = model.Email;
            appUser.Password = model.Password;

            if (ModelState.IsValid)
            {
                // _context.Add(appUser);
                _useRrepository.CreateUser(appUser);
                return RedirectToAction("Index", "Tasks");
            }
            return View(model);

        }

        [HttpGet]
        // Login action method should return view to login
        public ActionResult Login(string returnUrl)
        {

            return View();
        }

        // Login action method should handle post request and check whether the user is authenticated.
        // user should be redirected to Tasks list view after successfull registration
        // It should display and error message, if user is not authenticated

        public ActionResult Login(LoginViewModel model, string returnUrl)
        {

            AppUser appUser = new AppUser();
            appUser.Email = model.Email;
            appUser.Password = model.Password;

            if (ModelState.IsValid)
            {
                bool IsValidUser = _useRrepository.IsAuthenticated(appUser);

                if (IsValidUser)
                {
                    FormsAuthentication.SetAuthCookie(appUser.Email, false);
                    return RedirectToAction("Index", "Tasks");
                }
            }
            ModelState.AddModelError("", "invalid Username or Password");

            return View(model);
        }

        // LogOff action method should handle post request, sign out the user and redirect to login action method

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
