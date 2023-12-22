using DataAccess;
using Microsoft.AspNetCore.Mvc;
using PictureEditor.Models;

namespace PictureEditor.Controllers
{
    public class EffectController : Controller
    {
        private readonly ClientContext _db;

        public EffectController(ClientContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Add New Effect

        [HttpPost]
        public async Task<IActionResult> AddEffect(Effect effect)
        {
            if (ModelState.IsValid)
            {
                Effect newEffect = new Effect();
                newEffect.Name = newEffect.Name;
                newEffect.Description = newEffect.Description;
                newEffect.Type = newEffect.Type;

                await _db.Effects.AddAsync(newEffect);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        #endregion
    }
}
