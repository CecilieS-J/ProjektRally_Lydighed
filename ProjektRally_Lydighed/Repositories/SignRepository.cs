using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;

namespace ProjektRally_Lydighed.Repositories
{
    public class SignRepository : GenericRepository<Sign>, ISignRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SignRepository(ProjektRally_LydighedContext1 context, IWebHostEnvironment webHostEnvironment) : base(context)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task AddSignAsync(Sign sign)
        {
            _context.Sign.Add(sign);
            await _context.SaveChangesAsync();
        }

        public async Task<byte[]> GetImageData(string imagePath)
        {
            // Sammensæt stien til billedet baseret på placeringen i wwwroot-mappen
            var imagePathOnServer = Path.Combine(_webHostEnvironment.WebRootPath, "SignImages", imagePath);

            // Læs billedfilen som en byte-array
            byte[] imageData;
            using (var fileStream = new FileStream(imagePathOnServer, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
            }

            return imageData;
        }
    }
}
