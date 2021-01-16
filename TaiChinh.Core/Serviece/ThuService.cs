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
    public class ThuService : IThuService
    {
        private readonly TaiChinhContext _context;
       
        public ThuService(TaiChinhContext context)
        {
            _context = context;
        }

        public Task<Thu> DeleteThu(Thu entity)
        {
            _context.Thu.Remove(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<List<Thu>> GetAllThu()
        {
            return _context.Thu.Include(x=>x.TaiKhoan).ToListAsync();
        }

        public Task<Thu> GetThuById(long id)
        {
            return _context.Thu.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Thu>> GetThuFromTo(DateTime dateF, DateTime dateT)
        {
            return _context.Thu
                .Include(x=>x.TaiKhoan)
                .Where(x => x.DateCreate.Value.Date >= dateF.Date 
                            && dateT.Date >= x.DateCreate.Value.Date)
                .ToListAsync();
        }

        public Task<Thu> InsertThu(Thu entity)
        {
            entity.DateCreate = DateTime.Now;
            _context.Thu.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<Thu> UpdateThu(Thu entity)
        {
            _context.Thu.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }
        public Task<List<Thu>> GetThuByMonth(int month)
        {
            return _context.Thu
                .Include(x => x.TaiKhoan)
                .Where(x => x.DateCreate.Value.Month ==month)
                .ToListAsync();
        }
    }
}
