using AutoMapper;
using LMG.DAT.Interfaces;
using LMG.DAT.Models;

namespace LMG.DAT.UnitOfWork
{
    public class GeneralUnitOfWork<TDataModel, TDataContext> : IGeneralUnitOfWork<TDataModel, TDataContext> where TDataContext : DataContextBase
    {
        protected readonly IGenericRepository<TDataContext> Repository;
        private Mapper _Mapper;

        public GeneralUnitOfWork(IGenericRepository<TDataContext> repository)
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
            //Repository.SaveRepoAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new Exception("Not Found");
            }
            await Repository.Delete(id);
            await Repository.SaveRepoAsync();
        }


        public async Task InsertCollection(IEnumerable<TDataModel> models)
        {
            IEnumerable<TDataContext> entities = _Mapper.Map<IEnumerable<TDataModel>, IEnumerable<TDataContext>>(models);
            await Repository.InsertCollection(entities);
            await Repository.SaveRepoAsync();
        }


        public async Task Update(int id, TDataModel model)
        {
            var dbObj = await Repository.GetByIdAsync(id);
            TDataContext entity = _Mapper.Map<TDataModel, TDataContext>(model, dbObj);
            if (entity == null)
            {
                throw new Exception("does not exist");
            }
            Repository.Update(entity);
            await Repository.SaveRepoAsync();
        }

    }
}
