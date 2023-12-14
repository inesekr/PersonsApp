﻿using PersonsApp.Core.Models;
using PersonsApp.Core.Services;
using PersonsApp.Data;

namespace PersonsApp.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity

    {
        public EntityService(PersonDbContext context) : base(context)
        {
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public IQueryable<T> QueryById(int id)
        {
            return QueryById<T>(id);
        }
        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public T? GetById(int id)
        {
            return GetById<T>(id);
        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public bool Exists(int id)
        {
            return Exists<T>(id);
        }
    }
}