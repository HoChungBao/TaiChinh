using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;

namespace TaiChinh.Core.Serviece
{
    public class ChiService : IChiService
    {
        private readonly TaiChinhContext _context;
       
        public ChiService(TaiChinhContext context)
        {
            _context = context;
        }

        public Chi DeleteChi(Chi entity)
        {
            _context.Chi.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<Chi> GetAllChi()
        {
            return _context.Chi.Include(x=>x.TaiKhoan).Include(x=>x.TyLe).ToList();
        }
        
        public Chi GetChiById(long id)
        {
            return _context.Chi.FirstOrDefault(x => x.Id == id);
        }

        public Chi InsertChi(Chi entity)
        {

            entity.DateCreate = DateTime.Now;
            _context.Chi.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Chi UpdateChi(Chi entity)
        {
            _context.Chi.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<Chi> GetChiFromTo(DateTime dateF, DateTime dateT)
        {
            return _context.Chi.Include(x => x.TaiKhoan).Include(x => x.TyLe).Where(x => x.DateCreate.Value.Date >= dateF.Date && dateT.Date >= x.DateCreate.Value.Date).OrderByDescending(x=>x.DateCreate).ToList();
        }
    }
}
