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
    public class ChiService : IChiService
    {
        private readonly TaiChinhContext _context;
       
        public ChiService(TaiChinhContext context)
        {
            _context = context;
        }

        public Task<Chi> DeleteChi(Chi entity)
        {
            _context.Chi.Remove(entity);
            _context.SaveChanges();
            return Task.FromResult(entity); ;
        }

        public Task<List<Chi>> GetAllChi()
        {
            return _context.Chi
                .Include(x=>x.TaiKhoan)
                .Include(x=>x.TyLe)
                .ToListAsync();
        }
        
        public Task<Chi> GetChiById(long id)
        {
            return _context.Chi.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Chi> InsertChi(Chi entity)
        {

            entity.DateCreate = DateTime.Now;
            _context.Chi.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<Chi> UpdateChi(Chi entity)
        {
            _context.Chi.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<List<Chi>> GetChiFromTo(DateTime dateF, DateTime dateT)
        {
            return _context.Chi
                .Include(x => x.TaiKhoan)
                .Include(x => x.TyLe)
                .Where(x => x.DateCreate.Value.Date >= dateF.Date 
                && dateT.Date >= x.DateCreate.Value.Date)
                .OrderByDescending(x=>x.DateCreate)
                .ToListAsync();
        }
        public Task<List<Chi>> GetChiByMonth(int month)
        {
            return _context.Chi
                .Include(x => x.TaiKhoan)
                .Include(x => x.TyLe)
                .Where(x => x.DateCreate.Value.Date.Month >= month)
                .OrderByDescending(x => x.DateCreate)
                .ToListAsync();
        }
    }
}
