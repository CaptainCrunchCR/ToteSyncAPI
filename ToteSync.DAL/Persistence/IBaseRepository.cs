﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToteSync.DAL.Persistence
{
    public interface IBaseRepository <TEntity> where TEntity : class
    {
        IQueryable Query { get; }
        void Add(TEntity objModel);
        void AddRange(IEnumerable<TEntity> objModel);
        TEntity? GetById(int id);
        Task<TEntity?> GetByIdAsync(int id);
        TEntity? Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(TEntity objModel);
        void Remove(TEntity objModel);
    }
}
