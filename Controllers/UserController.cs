using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Interfaces;
using Asset.Models;
using Asset.Models.UserViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asset.Controllers
{
    public class UserController : Controller
    {
        private IRepository<Models.User> _repository;
        private IUserService<Models.User> _user;
        public UserController(IRepository<Models.User> userService, IUserService<User> user)
        {
            _user = user;
            _repository = userService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var users = _user.GetAllById(id);
            var listingresult = users.Select(result => new UserViewModel { Id = result.User_Id, FName = result.FName, LName = result.LName, EmailAddress = result.EmailAddress, FromDate = result.FromDate, ToDate = result.ToDate });

            return View(listingresult);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var result = _repository.Find(x => x.User_Id == id);
            if (result == null)
            {
                return NotFound();
            }
            UserViewModel userViewModel = new UserViewModel { FName = result.FName, LName = result.LName, EmailAddress = result.EmailAddress, Venue_Id = result.Venue_Id, FromDate = result.FromDate, ToDate = result.ToDate };
            return View(userViewModel);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user =_repository.GetById(userViewModel.Id);
                if(_user==null)
                {
                    User user = new User { User_Id = userViewModel.Id, FName = userViewModel.FName, LName = userViewModel.LName, EmailAddress = userViewModel.EmailAddress, Venue_Id = userViewModel.Venue_Id, FromDate = userViewModel.FromDate, ToDate = userViewModel.ToDate };

                    _repository.create(user);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var user = _repository.Find(x => x.User_Id == id);
            UserViewModel venueViewModel = new UserViewModel { Id = user.User_Id, FName = user.FName, LName = user.LName, EmailAddress = user.EmailAddress, Venue_Id = user.Venue_Id, FromDate = user.FromDate, ToDate = user.ToDate };
            return View(venueViewModel);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User { User_Id = userViewModel.Id, FName = userViewModel.FName, LName = userViewModel.LName, EmailAddress = userViewModel.EmailAddress, Venue_Id = userViewModel.Venue_Id, FromDate = userViewModel.FromDate, ToDate = userViewModel.ToDate };
                _repository.update(user);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var user = _repository.Find(x => x.User_Id == id);
            if (user == null)
            {
                return NotFound();
            }
            UserViewModel venueViewModel = new UserViewModel { Id = user.User_Id, FName = user.FName, LName = user.LName, EmailAddress = user.EmailAddress, Venue_Id = user.Venue_Id, FromDate = user.FromDate, ToDate = user.ToDate };
            return View(venueViewModel);
        }
        [HttpPost]
        public IActionResult Delete(string val, int? id)
        {
            var value = Request.Form["Yes"];
            if (id == null)
            {
                return new BadRequestResult();
            }
            var user = _repository.Find(x => x.User_Id == id);
            if (user == null)
            {
                return NotFound();
            }
            if (value == "true")
            {
                _repository.delete(user);
                return RedirectToAction("Index");
            }
            else
            {
                UserViewModel userViewModel = new UserViewModel { Id = user.User_Id, FName = user.FName, LName = user.LName, EmailAddress = user.EmailAddress, Venue_Id = user.Venue_Id, FromDate = user.FromDate, ToDate = user.ToDate };
                return View(userViewModel);
            }
        }
    }
}