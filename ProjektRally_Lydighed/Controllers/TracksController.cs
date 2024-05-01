using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Controllers;
using ProjektRally_Lydighed.Repositories;

namespace ProjektRally_Lydighed.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        

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

       /* // Handling til at håndtere træk-og-slip-operationer
        [HttpPost]
        public async Task<IActionResult> DragAndDrop(int trackId, int categoryId)
        {
            try
            {
                // Hent sporet fra databasen
                var track = await _trackRepository.GetByIdAsync(trackId);
                if (track == null)
                {
                    return NotFound();
                }

                // Find kategorien baseret på categoryId
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category == null)
                {
                    return NotFound();
                }

                // Opdater sporet med den nye kategori
                track.Category = category;

                // Gem ændringerne
                await _trackRepository.UpdateAsync(track);

                // Returner en bekræftelsesmeddelelse eller anden relevant respons
                return Ok("Træk-og-slip-operationen blev udført med succes.");
            }
            catch (Exception ex)
            {
                // Håndter eventuelle fejl og returner en passende respons
                return StatusCode(500, $"Fejl ved håndtering af træk-og-slip-operationen: {ex.Message}");
            }
        }*/

    }
}


/*using Microsoft.EntityFrameworkCore;
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
*/