using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.Models;
using System.Diagnostics;
using Application.Services;
using System.Net;
using Application.viewModels;

namespace POKEDEX.Controllers
{
    public class pokeController : Controller
    {

        private readonly PokeService contexto;

        public pokeController(ApplicationContext dbContexto)
        {
            this.contexto = new(dbContexto);
        }

        public async Task<IActionResult> Index()
        {
            var list = await contexto.GetAllViewModel();
            return View(list);
        }

        [HttpPost]
         public async Task<IActionResult> Index(String findregion, String findnombre)
         {
             List<PokeviewModel> regionwithpoke = new List<PokeviewModel>();
             var ps = await contexto.GetAllViewModel();


            if (findregion != null)
             {
                 int temp = Convert.ToInt32(findregion);
                 foreach (PokeviewModel i in ps)
                 {
                     if (i.RegionId == temp)
                     {
                         regionwithpoke.Add(i);
                     }
                 }
             }else
             {
                 foreach (PokeviewModel i in ps)
                 {
                     String temp = i.Name.Trim().ToLower();
                     if (temp.Equals(findnombre.ToLower()))
                     {
                         regionwithpoke.Add(i);
                     }
                 }
             }


             return View(regionwithpoke);
         }

        public async Task<IActionResult> mantenimiento()
        {
            var list = await contexto.GetAllViewModel();
            return View(list);
        }

        public IActionResult createPoke()
        {
            return View("actualizarPoke", new SavePokeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("actualizarPoke", vm);
            }

            await contexto.Add(vm);
            return RedirectToRoute(new { controller = "poke", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await contexto.Delete(id);

            return RedirectToRoute(new { controller = "poke", action = "mantenimiento" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("actualizarPoke", await contexto.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProduct", vm);
            }

            await contexto.Update(vm);
            return RedirectToRoute(new { controller = "poke", action = "mantenimiento" });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
