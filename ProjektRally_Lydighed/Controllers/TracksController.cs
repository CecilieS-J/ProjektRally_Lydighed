using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using AspNetCore;


namespace ProjektRally_Lydighed.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackRepository _trackRepository;
        private readonly ISignRepository _signRepository;
        private readonly ILogger<TracksController> _logger;

        private readonly IWebHostEnvironment _hostingEnvironment;
        // Injicer IWebHostEnvironment i din controllerens konstruktør
        public TracksController(ITrackRepository trackRepository, ISignRepository signRepository, ILogger<TracksController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _trackRepository = trackRepository;
            _signRepository = signRepository;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
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
        private async Task<byte[]> GetImageData(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                // Konverter billedfilen til en byte-array
                var imageFilePath = Path.Combine(_hostingEnvironment.WebRootPath, imagePath.TrimStart('/'));
                using (var stream = new FileStream(imageFilePath, FileMode.Open))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            return null;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Comment, Location, ReleaseDate")] Track track, List<IFormFile> signImages)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Gem de grundlæggende oplysninger om sporet
                    await _trackRepository.SaveTrackAsync(track);

                    // Gem tegnbillederne
                    foreach (var image in signImages)
                    {
                        if (image.Length > 0)
                        {
                            byte[] imageData;
                            using (var memoryStream = new MemoryStream())
                            {
                                await image.CopyToAsync(memoryStream);
                                imageData = memoryStream.ToArray();
                            }

                            var sign = new Sign
                            {
                                ImageData = imageData,
                                ImageContentType = image.ContentType,
                                TrackId = track.Id
                            };

                            await _signRepository.AddAsync(sign);
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
                return View(track);
            }
            catch (Exception ex)
            {
                // Log fejl og håndter fejlen
                _logger.LogError(ex, "Fejl under oprettelse af spor.");
                ModelState.AddModelError(string.Empty, "Der opstod en fejl under gemmeprocessen. Prøv igen senere.");
                return View(track);
            }
        }



        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Comment, Location, ReleaseDate")] Track track, IFormFile trackTemplate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Gem de grundlæggende oplysninger om sporet
                    await _trackRepository.SaveTrackAsync(track);

                    // Gem baneskabelonen (hvis den er blevet uploadet)
                    if (trackTemplate != null && trackTemplate.Length > 0)
                    {
                        // Konverter baneskabelonen til en byte-array
                        byte[] trackTemplateBytes;
                        using (var memoryStream = new MemoryStream())
                        {
                            await trackTemplate.CopyToAsync(memoryStream);
                            trackTemplateBytes = memoryStream.ToArray();
                        }

                        // Gem baneskabelonen i din database
                        track.Template = trackTemplateBytes;
                    }

                    // Hent alle placerede elementer på banen og gem dem
                    var elements = Request.Form["element"];
                    foreach (var elementId in elements)
                    {
                        if (int.TryParse(elementId, out int signId))
                        {
                            var sign = await _signRepository.GetByIdAsync(signId);
                            if (sign != null)
                            {
                                // Tilføj det placerede element til det gemte spor
                                track.Signs.Add(sign);
                            }
                        }
                    }

                    // Opdater spor i databasen med de gemte elementer
                    await _trackRepository.UpdateAsync(track);

                    return RedirectToAction(nameof(Index));
                }
                return View(track);
            }
            catch (Exception ex)
            {
                // Log fejlmeddelelse
                _logger.LogError(ex, "Fejl under oprettelse af spor.");

                // Tilføj en fejlmeddelelse til modelens fejltilstand
                ModelState.AddModelError(string.Empty, "Der opstod en fejl under gemmeprocessen. Prøv igen senere.");

                // Returner visningen med modelen, der indeholder fejl
                return View(track);
            }
        }
        */


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