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
    public class RegionService
    {
        private readonly regionRepository _repository;

        public RegionService(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task Add(saveRegionViewModel vm)
        {
            regions pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;
            pk.Description = vm.Description;

            await _repository.AddAsync(pk);
        }

        public async Task Update(saveRegionViewModel vm)
        {
            regions pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;
            pk.Description = vm.Description;

            await _repository.UpdateAsync(pk);
        }

        public async Task Delete(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pk);
        }

        public async Task<saveRegionViewModel> GetByIdSaveViewModel(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            saveRegionViewModel vm = new();
            vm.Id = pk.Id;
            vm.Name = pk.Name;
            vm.Description = pk.Description;

            return vm;
        }

        public async Task<List<RegionviewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new RegionviewModel
            {
                Name = s.Name,
                Description = s.Description,
                Id = s.Id

            }).ToList();
        }
    }
}