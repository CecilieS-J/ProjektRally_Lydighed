using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;

        // Constructor injection for ITrackRepository
        public TracksController(ITrackRepository trackRepository)
        {
            _trackRepository = trackRepository;
        }

        // Action for displaying list of tracks
        public async Task<IActionResult> Index()
        {
            var tracks = await _trackRepository.GetAllAsync();
            return View(tracks);
        }

        // Action for displaying details of a track
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

        // Action for displaying form to create a new track
        public IActionResult Create()
        {
            return View();
        }

        // Action for handling creation of a new track
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Comment,Location,ReleaseDate")] Track track)
        {
            // Check if the model state is valid before proceeding
            if (ModelState.IsValid)
            {
                await _trackRepository.AddAsync(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // Action for displaying form to edit an existing track
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
    }
}
