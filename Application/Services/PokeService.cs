using Application.Repository;
using Application.viewModels;
using Persistencia;
using Persistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PokeService
    {
        private readonly PokeRepository _repository;

        public PokeService(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task Add(SavePokeViewModel vm)
        {
            Pokemons pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;
            pk.Description = vm.Description;
            pk.ImgUrl = vm.ImgUrl;
            pk.PrimaryType = vm.PrimaryType;
            pk.SecondaryType = vm.SecondaryType;
            pk.RegionId = vm.RegionId;

            await _repository.AddAsync(pk);
        }

        public async Task Update(SavePokeViewModel vm)
        {
            Pokemons pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;
            pk.Description = vm.Description;
            pk.ImgUrl = vm.ImgUrl;
            pk.PrimaryType = vm.PrimaryType;
            pk.SecondaryType = vm.SecondaryType;
            pk.RegionId = vm.RegionId;

            await _repository.UpdateAsync(pk);
        }

        public async Task Delete(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pk);
        }

        public async Task<SavePokeViewModel> GetByIdSaveViewModel(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            SavePokeViewModel vm = new();
            vm.Id = pk.Id;
            vm.Name = pk.Name;
            vm.Description = pk.Description;
            vm.ImgUrl = pk.ImgUrl;
            vm.PrimaryType = pk.PrimaryType;
            vm.SecondaryType = pk.SecondaryType;
            vm.RegionId = pk.RegionId;

            return vm;
        }

        public async Task<List<PokeviewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new PokeviewModel
            {
                Name = s.Name,
                Description = s.Description,
                Id = s.Id,
                PrimaryType = s.PrimaryType,
                SecondaryType = s.SecondaryType,
                RegionId = s.RegionId,
                ImgUrl = s.ImgUrl

            }).ToList();
        }
    }
}