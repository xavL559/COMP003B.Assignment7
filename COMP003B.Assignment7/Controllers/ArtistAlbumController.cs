using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.Assignment7.Models;
using COMP003B.LectureActivity7.Data;

namespace COMP003B.Assignment7.Controllers
{
    public class ArtistAlbumController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public ArtistAlbumController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: ArtistAlbum
        public async Task<IActionResult> Index()
        {
              return _context.ArtistAlbumViewModel != null ? 
                          View(await _context.ArtistAlbumViewModel.ToListAsync()) :
                          Problem("Entity set 'WebDevAcademyContext.ArtistAlbumViewModel'  is null.");
        }

        // GET: ArtistAlbum/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ArtistAlbumViewModel == null)
            {
                return NotFound();
            }

            var artistAlbumViewModel = await _context.ArtistAlbumViewModel
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artistAlbumViewModel == null)
            {
                return NotFound();
            }

            return View(artistAlbumViewModel);
        }

        // GET: ArtistAlbum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtistAlbum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistId,AlbumId")] ArtistAlbumViewModel artistAlbumViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artistAlbumViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artistAlbumViewModel);
        }

        // GET: ArtistAlbum/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ArtistAlbumViewModel == null)
            {
                return NotFound();
            }

            var artistAlbumViewModel = await _context.ArtistAlbumViewModel.FindAsync(id);
            if (artistAlbumViewModel == null)
            {
                return NotFound();
            }
            return View(artistAlbumViewModel);
        }

        // POST: ArtistAlbum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ArtistId,AlbumId")] ArtistAlbumViewModel artistAlbumViewModel)
        {
            if (id != artistAlbumViewModel.ArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artistAlbumViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistAlbumViewModelExists(artistAlbumViewModel.ArtistId))
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
            return View(artistAlbumViewModel);
        }

        // GET: ArtistAlbum/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ArtistAlbumViewModel == null)
            {
                return NotFound();
            }

            var artistAlbumViewModel = await _context.ArtistAlbumViewModel
                .FirstOrDefaultAsync(m => m.ArtistId == id);
            if (artistAlbumViewModel == null)
            {
                return NotFound();
            }

            return View(artistAlbumViewModel);
        }

        // POST: ArtistAlbum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ArtistAlbumViewModel == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.ArtistAlbumViewModel'  is null.");
            }
            var artistAlbumViewModel = await _context.ArtistAlbumViewModel.FindAsync(id);
            if (artistAlbumViewModel != null)
            {
                _context.ArtistAlbumViewModel.Remove(artistAlbumViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtistAlbumViewModelExists(string id)
        {
          return (_context.ArtistAlbumViewModel?.Any(e => e.ArtistId == id)).GetValueOrDefault();
        }
    }
}
