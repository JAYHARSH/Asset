using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Interfaces;
using Asset.Models;
using Asset.Models.VenueViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Asset.Controllers
{
    public class VenueController : Controller
    {
        private IRepository<Models.Venue> _repository;
        public VenueController(IRepository<Models.Venue> venueService)
        {
            _repository = venueService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var venues = _repository.GetAll();
            var listingresult = venues.Select(result => new VenueViewModel { Id = result.Venue_Id, Venue_Name = result.Venue_Name, Size = result.Size, Location = result.Location, Cost = result.Cost });

            return View(listingresult);
        }
        [HttpPost]
        public IActionResult Index(double size)
        {
            var venues=_repository.SearchAll(x => x.Size == size);
            var listingresult = venues.Select(result => new VenueViewModel { Id = result.Venue_Id, Venue_Name = result.Venue_Name, Size = result.Size, Location = result.Location, Cost = result.Cost });

            return View(listingresult);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var venue = _repository.Find(x => x.Venue_Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            VenueViewModel venueViewModel = new VenueViewModel { Id = venue.Venue_Id, Venue_Name = venue.Venue_Name, Size = venue.Size, Location = venue.Location };
            return View(venueViewModel);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VenueViewModel venueViewModel)
        {
            if (ModelState.IsValid)
            {
                Venue venue = new Venue { Venue_Id = venueViewModel.Id, Venue_Name = venueViewModel.Venue_Name, Size = venueViewModel.Size, Location = venueViewModel.Location, Cost = venueViewModel.Cost };

                _repository.create(venue);
            }
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var venue = _repository.Find(x => x.Venue_Id == id);
            VenueViewModel venueViewModel = new VenueViewModel { Id = venue.Venue_Id, Venue_Name = venue.Venue_Name, Size = venue.Size, Location = venue.Location };
            return View(venueViewModel);
        }
        [HttpPost]
        public IActionResult Edit(VenueViewModel venueViewModel)
        {
            if (ModelState.IsValid)
            {
                Venue venue = new Venue { Venue_Id = venueViewModel.Id, Venue_Name = venueViewModel.Venue_Name, Size = venueViewModel.Size, Location = venueViewModel.Location, Cost = venueViewModel.Cost };
                _repository.update(venue);
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var venue = _repository.Find(x => x.Venue_Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            VenueViewModel venueViewModel = new VenueViewModel { Id = venue.Venue_Id, Venue_Name = venue.Venue_Name, Size = venue.Size, Location = venue.Location };
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
            var venue = _repository.Find(x => x.Venue_Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            if (value == "true")
            {
                _repository.delete(venue);
                return RedirectToAction("Index");
            }
            else
            {
                VenueViewModel venueViewModel = new VenueViewModel { Id = venue.Venue_Id, Venue_Name = venue.Venue_Name, Size = venue.Size, Location = venue.Location };
                return View(venueViewModel);
            }
        }

    }

   }