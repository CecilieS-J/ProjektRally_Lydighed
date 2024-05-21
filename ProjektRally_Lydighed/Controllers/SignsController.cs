using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Repositories;

namespace ProjektRally_Lydighed.Controllers
{

   public class SignsController : Controller
     {
         private readonly ISignRepository _signRepository;

         public SignsController(ISignRepository signRepository)
         {
             _signRepository = signRepository;
         }

         // GET: Signs
         // Denne metode er tilgængelig for alle brugere
         [AllowAnonymous]

         public async Task<IActionResult> Index()
         {
             return View(await _signRepository.GetAllAsync());
         }

         // GET: Signs/Details/5
         public async Task<IActionResult> Details(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var sign = await _signRepository.GetByIdAsync(id.Value);
             if (sign == null)
             {
                 return NotFound();
             }

             return View(sign);
         }

         // GET: Signs/Create
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         public IActionResult Create()
         {
             return View();
         }

         // POST: Signs/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("Id,SignNumber")] Sign sign)
         {
             if (ModelState.IsValid)
             {
                 await _signRepository.AddAsync(sign);
                 return RedirectToAction(nameof(Index));
             }
             return View(sign);
         }

         // GET: Signs/Edit/5
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var sign = await _signRepository.GetByIdAsync(id.Value);
             if (sign == null)
             {
                 return NotFound();
             }
             return View(sign);
         }

         // POST: Signs/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to.
         // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,SignNumber,XCoordinate,YCoordinate,Rotation")] Sign sign)
         {
             if (id != sign.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     await _signRepository.UpdateAsync(sign);

                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!await SignExistsAsync(sign.Id))
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
             return View(sign);
         }

         // GET: Signs/Delete/5
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         public async Task<IActionResult> Delete(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var sign = await _signRepository.GetByIdAsync(id.Value);
             if (sign == null)
             {
                 return NotFound();
             }

             return View(sign);
         }

         // POST: Signs/Delete/5
         // Denne metode er kun tilgængelig for godkendte brugere

         [Authorize]
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(int id)
         {
             var sign = await _signRepository.GetByIdAsync(id);
             if (sign != null)
             {
                 await _signRepository.DeleteAsync(sign);
             }

               return RedirectToAction(nameof(Index));
         }

         private async Task<bool> SignExistsAsync(int id)
         {
             var sign = await _signRepository.GetByIdAsync(id);
             return sign != null;
         }
     }
}
