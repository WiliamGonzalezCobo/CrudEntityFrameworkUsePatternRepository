using System;
using System.Collections.Generic;

namespace EF_Repo.PatternRepository
{
    interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T model);
        void Update(T model);
        void Delete(object id);
        void Save();
    }
}
