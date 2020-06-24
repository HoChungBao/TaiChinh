using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaiChinh.Core.Entities;
using TaiChinh.Core.Interface;

namespace TaiChinh.Core.Serviece
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly TaiChinhContext _context;
        
        public TaiKhoanService(TaiChinhContext context)
        {
            _context = context;
        }
        public TaiKhoan DeleteTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public List<TaiKhoan> GetAllTaiKhoan()
        {
            return _context.TaiKhoan.ToList();
        }

        public TaiKhoan GetTaiKhoanById(long id)
        {
            return _context.TaiKhoan.FirstOrDefault(x=>x.Id==id);
        }

        public TaiKhoan InsertTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public TaiKhoan UpdateTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
