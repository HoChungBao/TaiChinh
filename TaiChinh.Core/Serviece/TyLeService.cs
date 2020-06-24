using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;

namespace TaiChinh.Core.Serviece
{
    public class TyLeService : ITyLeService
    {
        private readonly TaiChinhContext _context;
        
        public TyLeService(TaiChinhContext context)
        {
            _context = context;
        }

        public TyLe DeleteTyLe(TyLe entity)
        {
            _context.TyLe.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<TyLe> GetAllTyLe()
        {

            return _context.TyLe.ToList();
        }

        public TyLe GetTyLeById(long id)
        {
            return _context.TyLe.FirstOrDefault(x => x.Id == id);
        }

        public TyLe InsertTyLe(TyLe entity)
        {

            entity.DateCreate = DateTime.Now;
            _context.TyLe.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TyLe UpdateTyLe(TyLe entity)
        {
            _context.TyLe.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
