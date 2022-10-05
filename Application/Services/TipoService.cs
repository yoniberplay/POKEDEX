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
    public class TipoService
    {
        private readonly TipoRepository _repository;

        public TipoService(ApplicationContext dbContext)
        {
            _repository = new(dbContext);
        }

        public async Task Add(saveTipoViewModel vm)
        {
            tipos pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;

            await _repository.AddAsync(pk);
        }

        public async Task Update(saveTipoViewModel vm)
        {
            tipos pk = new();
            pk.Id = vm.Id;
            pk.Name = vm.Name;

            await _repository.UpdateAsync(pk);
        }

        public async Task Delete(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(pk);
        }

        public async Task<saveTipoViewModel> GetByIdSaveViewModel(int id)
        {
            var pk = await _repository.GetByIdAsync(id);
            saveTipoViewModel vm = new();
            vm.Id = pk.Id;
            vm.Name = pk.Name;

            return vm;
        }

        public async Task<List<TipoviewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(s => new TipoviewModel
            {
                Name = s.Name,
                Id = s.Id

            }).ToList();
        }
    }
}