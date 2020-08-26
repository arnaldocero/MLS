using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLS.Web.Data;
using MLS.Web.Data.Entities;
using MLS.Web.Helpers;
using MLS.Web.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MLS.Web.Controllers
{
    [Authorize(Roles = "Administrador,Usertrabajador,Userpaciente")]
    
    public class DocumentoEntitiesController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        
       

        public DocumentoEntitiesController(DataContext context,
            IUserHelper userHelper
            )
        {
            _context = context;
            _userHelper = userHelper;
           
        }

        // GET: DocumentoEntities
        public async Task<IActionResult> Index()
        {
          var user=  await this._userHelper.GetUserAsync(User.Identity.Name);

            return View(await _context.Documento.Where(d=> d.User==user).ToListAsync());
        }

        public async Task<IActionResult> Indexx()
        {
            var user = await this._userHelper.GetUserAsync(User.Identity.Name);

            return View(await _context.Documento.Where(d => d.User == user).ToListAsync());
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
        public async Task<IActionResult> Create( DocumentoViewModel view)
        {
            if (ModelState.IsValid)
            {

                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\pdf\\archivos", view.ImageFile.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/pdf/archivos/{view.ImageFile.FileName}";
                }




                // TODO: Pending to change to: this.User.Identity.Name
                view.User = await this._userHelper.GetUserAsync(view.Email);
                var product = this.ToDocumen(view, path);
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(view);

        }
        private DocumentoEntity ToDocumen(DocumentoViewModel view, string path)
        {
            return new DocumentoEntity
            {
                Id = view.Id,
                Name = view.Name,
                Document = view.Document,
                FirstName = view.FirstName,
                Email=view.Email,
                pdfUrl = path,
                UploadDate=view.UploadDate,
                User = view.User
            };
        }


        // GET: DocumentoEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var documento = await this._context.Documento.FindAsync(id.Value);
            if (documento == null)
            {
                return NotFound();
            }

            var view = this.ToDocumenViewModel(documento);
            return View(view);


            /*DocumentoEntity documentoEntity = await _context.Documento.FindAsync(id);
            if (documentoEntity == null)
            {
                return NotFound();
            }
            return View(documentoEntity);*/
        }
        private DocumentoViewModel ToDocumenViewModel(DocumentoEntity documento)
        {
            return new DocumentoViewModel
            {
                Id = documento.Id,
                Name =documento.Name,
                Document = documento.Document,
                FirstName = documento.FirstName,
                Email=documento.Email,
                pdfUrl = documento.pdfUrl,
                UploadDate = documento.UploadDate,
                User = documento.User
            };
        }


        // POST: DocumentoEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentoViewModel view)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.pdfUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\pdf\\archivos", 
                            view.ImageFile.FileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/pdf/archivos/{view.ImageFile.FileName}";
                    }

                    // TODO: Pending to change to: this.User.Identity.Name
                    view.User = await this._userHelper.GetUserAsync(view.Email);
                    var product = this.ToDocumen(view, path);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.DocumentoEntityExists(view.Id))
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
            return View(view);

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
