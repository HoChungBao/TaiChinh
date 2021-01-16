using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Task<TaiKhoan> DeleteTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Remove(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<List<TaiKhoan>> GetAllTaiKhoan()
        {
            return _context.TaiKhoan.ToListAsync();
        }

        public Task<TaiKhoan> GetTaiKhoanById(long id)
        {
            return _context.TaiKhoan.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<TaiKhoan> InsertTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<TaiKhoan> UpdateTaiKhoan(TaiKhoan entity)
        {
            _context.TaiKhoan.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<TaiKhoan> GetTaiKhoanThuChiById(long id)
        {
            return _context.TaiKhoan
                //Tất cả tiền thu của tài khoản
                .Include(x=>x.ThuTaiKhoan)
                //Tất cả tiền chi của tài khoản
                .Include(x => x.Chi)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<TaiKhoan> GetTaiKhoanThuChiByIdDate(long id, int month)
        {
            return _context.TaiKhoan
                //Tất cả tiền thu của tài khoản
                .Include(x => x.ThuTaiKhoan.Where(x=>x.DateCreate.Value.Month==month))
                //Tất cả tiền chi của tài khoản
                .Include(x => x.Chi.Where(x => x.DateCreate.Value.Month == month))
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<TaiKhoan> GetTaiKhoanThuChiByIdYear(long id, int year)
        {
            return _context.TaiKhoan
                //Tất cả tiền thu của tài khoản
                .Include(x => x.ThuTaiKhoan.Where(x => x.DateCreate.Value.Year == year))
                //Tất cả tiền chi của tài khoản
                .Include(x => x.Chi.Where(x => x.DateCreate.Value.Year == year))
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
