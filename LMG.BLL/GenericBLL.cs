using AutoMapper;
using LMG.DAT.Interfaces;
using LMG.DAT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMG.BLL
{
    public class GenericBLL<TDataModel, TDataContext> where TDataContext : DataContextBase
    {
        protected readonly GenericRepository<TDataContext> Repository;
        private Mapper _Mapper;

        public GenericBLL(GenericRepository<TDataContext> repository)
        {
            Repository = repository;
            var _config = new MapperConfiguration(cfg => cfg.CreateMap<TDataContext, TDataModel>().ReverseMap());
            _Mapper = new Mapper(_config);
        }

        public async Task<ICollection<TDataModel>> GetAll()
        {
            ICollection<TDataContext> objFromDb = await Repository.GetAllAsync(0, 5);
            ICollection<TDataModel> model = _Mapper.Map<ICollection<TDataContext>, ICollection<TDataModel>>(objFromDb);

            return model;
        }

        public async Task<TDataModel> GetById(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            TDataModel model = _Mapper.Map<TDataContext, TDataModel>(entity);
            return model;
        }

        public void Insert(TDataModel model)
        {
            TDataContext entity = _Mapper.Map<TDataModel, TDataContext>(model);
            Repository.Insert(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if(entity == null)
            {
                throw new Exception("Not Found");
            }
            await Repository.Delete(id);
        }

        
        public async Task InsertCollection(IEnumerable<TDataModel> models)
        {
            IEnumerable<TDataContext> entities = _Mapper.Map<IEnumerable<TDataModel>, IEnumerable<TDataContext>>(models);
            await Repository.InsertCollection(entities);
        }
        

        public async Task Update(int id, TDataModel model)
        {
            var dbObj = await Repository.GetByIdAsync(id);
            TDataContext entity = _Mapper.Map<TDataModel, TDataContext>(model, dbObj);
            if(entity == null)
            {
                throw new Exception("does not exist");
            }
            Repository.Update(entity);
        }
    }
}
