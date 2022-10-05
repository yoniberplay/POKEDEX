using Application.Services;
using Application.viewModels;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace POKEDEX.Controllers
{
    public class regionController : Controller
    {

        private readonly RegionService contexto;

        public regionController(ApplicationContext dbContexto)
        {
            this.contexto = new(dbContexto);
        }

        public async Task<IActionResult> mantenimiento()
        {
            var list = await contexto.GetAllViewModel();
            return View(list);
        }

        public IActionResult createRegion()
        {
            return View("actualizarRegion", new saveRegionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(saveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("actualizarRegion", vm);
            }

            await contexto.Add(vm);
            return RedirectToRoute(new { controller = "region", action = "mantenimiento" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await contexto.Delete(id);

            return RedirectToRoute(new { controller = "region", action = "mantenimiento" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("actualizarRegion", await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(saveRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", vm);
            }

            await contexto.Update(vm);
            return RedirectToRoute(new { controller = "region", action = "mantenimiento" });
        }

    }
}
