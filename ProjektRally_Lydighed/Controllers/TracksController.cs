using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Controllers;
using ProjektRally_Lydighed.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjektRally_Lydighed.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        private readonly ISignRepository _signRepository;

        public TracksController(ITrackRepository trackRepository, ISignRepository signRepository)
        {
            _trackRepository = trackRepository;
            _signRepository = signRepository;
        }

        // Action for displaying list of tracks
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var tracks = await _trackRepository.GetAllAsync();
            return View(tracks);
        }

        // Action for displaying details of a track
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        [Authorize]
        public IActionResult Create()
        {
            var signs = _signRepository.GetAllAsync().Result;
            ViewBag.Signs = new SelectList(signs, "Id", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Location,ReleaseDate,SignIds")] Track track, int[] selectedSignIds)
        {
            if (ModelState.IsValid)
            {
                track.Signs = new List<Sign>();
                foreach (var signId in selectedSignIds)
                {
                    var sign = await _signRepository.GetByIdAsync(signId);
                    if (sign != null)
                    {
                        track.Signs.Add(sign);
                    }
                }
                await _trackRepository.AddAsync(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Location,ReleaseDate")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _trackRepository.UpdateAsync(track);
                }
                catch (Exception)
                {
                    if (!await TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            if (track != null)
            {
                await _trackRepository.DeleteAsync(track);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TrackExists(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            return track != null;
        }
    }

    /*public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        private readonly ISignRepository _signRepository;



        public TracksController(ITrackRepository trackRepository, ISignRepository signRepository)
        {
            _trackRepository = trackRepository;
            _signRepository = signRepository;

        }

        // Action for displaying list of tracks
        // Denne metode er tilgængelig for alle brugere
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var tracks = await _trackRepository.GetAllAsync();
            return View(tracks);
        }

        // Action for displaying details of a track
        // Denne metode er tilgængelig for alle brugere
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }
        [Authorize]
        public IActionResult Create()
        {
            // Fetch all signs to display them for selection
            var signs = _signRepository.GetAllAsync().Result;
            ViewBag.Signs = new SelectList(signs, "Id", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Location,ReleaseDate,SignIds")] Track track, int[] selectedSignIds)
        {
            if (ModelState.IsValid)
            {
                track.Signs = new List<Sign>();
                foreach (var signId in selectedSignIds)
                {
                    var sign = await _signRepository.GetByIdAsync(signId);
                    if (sign != null)
                    {
                        track.Signs.Add(sign);
                    }
                }
                await _trackRepository.AddAsync(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // Action for displaying form to create a new track

        // Denne metode er kun tilgængelig for godkendte brugere

        /* [Authorize]
         public IActionResult Create()
         {
             return View();
         }




         // Action for handling creation of a new track
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         [HttpPost]
               [ValidateAntiForgeryToken]
               public async Task<IActionResult> Create([Bind("Id,Name,Comment,Location,ReleaseDate")] Track track)
               {
                   // Check if the model state is valid before proceeding
                   if (ModelState.IsValid)
                   {
                       await _trackRepository.SaveTrackAsync(track);
                       return RedirectToAction(nameof(Index));
                   }
                   return View(track);
               }

         // Action for displaying form to edit an existing track
         // Denne metode er kun tilgængelig for godkendte brugere

    [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // Action for handling editing of an existing track
        // Denne metode er kun tilgængelig for godkendte brugere

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Comment,Location,ReleaseDate")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _trackRepository.UpdateAsync(track);
                }
                catch (Exception)
                {
                    if (!await TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // Action for displaying confirmation page before deleting a track
        // Denne metode er kun tilgængelig for godkendte brugere

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var track = await _trackRepository.GetByIdAsync(id.Value);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // Action for handling deletion of a track
        // Denne metode er kun tilgængelig for godkendte brugere

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            if (track != null)
            {
                await _trackRepository.DeleteAsync(track);
            }

            return RedirectToAction(nameof(Index));
        }

        // Helper method to check if a track exists
        private async Task<bool> TrackExists(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            return track != null;
        }

      
    }*/
}