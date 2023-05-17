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
    public class AlbumController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public AlbumController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
              return _context.Album != null ? 
                          View(await _context.Album.ToListAsync()) :
                          Problem("Entity set 'WebDevAcademyContext.AlbumTitle'  is null.");
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var albumViewModel = await _context.Album
                .FirstOrDefaultAsync(m => m.AlbumTitle == id);
            if (albumViewModel == null)
            {
                return NotFound();
            }

            var artist = from s in _context.Artist
                           join e in _context.ArtistAlbum on s.Artist equals e.Artist
                           join c in _context.Album on e.Artist equals c.AlbumTitle
                           where c.AlbumTitle == id
                           select s;


            return View(albumViewModel);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumTitle")] AlbumViewModel albumViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(albumViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(albumViewModel);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var albumViewModel = await _context.Album.FindAsync(id);
            if (albumViewModel == null)
            {
                return NotFound();
            }
            return View(albumViewModel);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Album")] AlbumViewModel albumViewModel)
        {
            if (id != albumViewModel.AlbumTitle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(albumViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumViewModelExists(albumViewModel.AlbumTitle))
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
            return View(albumViewModel);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var albumViewModel = await _context.Album
                .FirstOrDefaultAsync(m => m.AlbumTitle == id);
            if (albumViewModel == null)
            {
                return NotFound();
            }

            return View(albumViewModel);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Album == null)
            {
                return Problem("Entity set 'WebDevAcademyContext.AlbumTitle'  is null.");
            }
            var albumViewModel = await _context.Album.FindAsync(id);
            if (albumViewModel != null)
            {
                _context.Album.Remove(albumViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumViewModelExists(string id)
        {
          return (_context.Album?.Any(e => e.AlbumTitle == id)).GetValueOrDefault();
        }

        
    }
}
