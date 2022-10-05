using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Application.Services;
using Application.viewModels;


namespace POKEDEX.Controllers
{
    public class tipoController : Controller
    {
        private readonly TipoService contexto;

        public tipoController(ApplicationContext dbContexto)
        {
            this.contexto = new(dbContexto);
        }

        public async Task<IActionResult> mantenimiento()
        {
            var list = await contexto.GetAllViewModel();
            return View(list);
        }

        public IActionResult createTipo()
        {
            return View("actualizarTipo", new saveTipoViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(saveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("actualizarTipo", vm);
            }

            await contexto.Add(vm);
            return RedirectToRoute(new { controller = "tipo", action = "mantenimiento" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await contexto.Delete(id);

            return RedirectToRoute(new { controller = "tipo", action = "mantenimiento" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("actualizarTipo", await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(saveTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", vm);
            }

            await contexto.Update(vm);
            return RedirectToRoute(new { controller = "tipo", action = "mantenimiento" });
        }

    }
}
