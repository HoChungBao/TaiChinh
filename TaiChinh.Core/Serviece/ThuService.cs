using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;

namespace TaiChinh.Core.Serviece
{
    public class ThuService : IThuService
    {
        private readonly TaiChinhContext _context;
       
        public ThuService(TaiChinhContext context)
        {
            _context = context;
        }

        public Thu DeleteThu(Thu entity)
        {
            _context.Thu.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<Thu> GetAllThu()
        {
            return _context.Thu.Include(x=>x.TaiKhoan).ToList();
        }

        public Thu GetThuById(long id)
        {
            return _context.Thu.FirstOrDefault(x => x.Id == id);
        }

        public List<Thu> GetThuFromTo(DateTime dateF, DateTime dateT)
        {
            return _context.Thu.Include(x=>x.TaiKhoan).Where(x => x.DateCreate >= dateF && dateT >= x.DateCreate).ToList();
        }

        public Thu InsertThu(Thu entity)
        {
            entity.DateCreate = DateTime.Now;
            _context.Thu.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Thu UpdateThu(Thu entity)
        {
            _context.Thu.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
