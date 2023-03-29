﻿using Microsoft.EntityFrameworkCore;
using Produtos.Data;
using Produtos.Repositories.Contracts;

namespace Produtos.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly AppDbContext _AppDbContext;
        private readonly DbSet<TEntity> _DbSet;

        public RepositoryBase(AppDbContext db)
        {
            _DbSet = db.Set<TEntity>();
            _AppDbContext = db;
        }

        public void Add(TEntity obj)
        {
            _DbSet.Add(obj);
            _AppDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _DbSet.Remove(Get(id));
            _AppDbContext.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return _DbSet.ToList();
        }

        public TEntity Get(int id)
        {
            return _DbSet.Find(id);
        }

        public void Update(TEntity obj)
        {
            _DbSet.Update(obj);
            _AppDbContext.SaveChanges();
        }
    }
}
