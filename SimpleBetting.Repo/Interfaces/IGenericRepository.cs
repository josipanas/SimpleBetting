﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleBetting.Repo.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Save();
    }
}