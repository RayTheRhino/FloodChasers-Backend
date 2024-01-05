using System;
using System.Linq;
using FloodChasersModel.Dao;
using Microsoft.EntityFrameworkCore;

namespace FloodChasersLogic.Dao;
public class GenericDao<T> :IGenericDeo<T> where T : class 
{
    private readonly AppDbContext _context;

    public GenericDao(AppDbContext context)
    {
        _context = context;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public T GetById(string id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var entity = _context.Set<T>().Find(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }

    public void DeleteAll()
    {
        var entities  = _context.Set<T>().ToList();
        _context.Set<T>().RemoveRange(entities);
        _context.SaveChanges();
    }
}
