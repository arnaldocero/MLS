using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLS.Web.Data;
using MLS.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MLS.Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DocumentoEntitiesController : Controller
    {
        private readonly DataContext _context;

        public DocumentoEntitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: DocumentoEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documento.ToListAsync());
        }

        // GET: DocumentoEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentoEntity documentoEntity = await _context.Documento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentoEntity == null)
            {
                return NotFound();
            }

            return View(documentoEntity);
        }

        // GET: DocumentoEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentoEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Document,FirstName,pdfUrl,UploadDate")] DocumentoEntity documentoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentoEntity);
        }

        // GET: DocumentoEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentoEntity documentoEntity = await _context.Documento.FindAsync(id);
            if (documentoEntity == null)
            {
                return NotFound();
            }
            return View(documentoEntity);
        }

        // POST: DocumentoEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Document,FirstName,pdfUrl,UploadDate")] DocumentoEntity documentoEntity)
        {
            if (id != documentoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoEntityExists(documentoEntity.Id))
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
            return View(documentoEntity);
        }

        // GET: DocumentoEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DocumentoEntity documentoEntity = await _context.Documento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentoEntity == null)
            {
                return NotFound();
            }

            return View(documentoEntity);
        }

        // POST: DocumentoEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            DocumentoEntity documentoEntity = await _context.Documento.FindAsync(id);
            _context.Documento.Remove(documentoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoEntityExists(int id)
        {
            return _context.Documento.Any(e => e.Id == id);
        }
    }
}
