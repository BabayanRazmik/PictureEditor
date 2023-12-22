using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PictureEditor.Models;
using PictureEditor.ModelsView;

namespace PictureEditor.Controllers
{
    public class PictureController : Controller
    {
        private readonly ClientContext _db;

        public PictureController(ClientContext db)
        {
            _db = db;
        }

        #region All picture

        [HttpGet]
        public async Task<IActionResult> Allpictures()
        {
            var Pictures = await _db.Pictures.ToListAsync();

            return View(Pictures);
        }

        #endregion

        #region One picture

        [HttpGet]
        public async Task<IActionResult> OnePicture(int Id)
        {
            var picture = await _db.Pictures.Where(u => u.Id == Id).FirstOrDefaultAsync();

            return View(picture);
        }

        #endregion

        #region Add Picture

        [HttpPost]
        public async Task<IActionResult> AddPicture(Picture picture)
        {
            if (ModelState.IsValid)
            {
                Picture newPicture = new Picture();
                newPicture.Name = picture.Name;
                newPicture.EffectId = picture.EffectId;
                newPicture.TransformId = newPicture.TransformId;

                await _db.Pictures.AddAsync(newPicture);
                await _db.SaveChangesAsync();

                return RedirectToAction("AllPictures");
            }

            return NotFound();
        }

        #endregion

        #region Edit Picture
        [HttpGet]
        public async Task<IActionResult> EditPicture(int Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var picture = await _db.Pictures.FindAsync(Id);

            return View(picture);
        }

        [HttpPost]
        public async Task<IActionResult> EditPicture(PictureModel picture)
        {
            Picture editPicture = await _db.Pictures.Where(u => u.Id == picture.Id).FirstOrDefaultAsync();

            if (ModelState.IsValid && editPicture != null)
            {
                editPicture.Name = picture.Name;
                editPicture.EffectId = editPicture.EffectId;

                var transform = new Transform();

                transform.PictureId = picture.Id;
                transform.Crop = picture.Crop;
                transform.Radius = picture.Radius;
                transform.Size = picture.Crop;
                transform.Vertical = picture.Vertical;
                transform.Horizontal = picture.Vertical;

                
                _db.Entry(transform).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                _db.Entry(editPicture).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return RedirectToAction("AllContacts");
            }

            return NotFound();
        }

        #endregion

    }
}
