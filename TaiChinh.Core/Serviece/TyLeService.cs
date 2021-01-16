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
    public class TyLeService : ITyLeService
    {
        private readonly TaiChinhContext _context;
        
        public TyLeService(TaiChinhContext context)
        {
            _context = context;
        }

        public Task<TyLe> DeleteTyLe(TyLe entity)
        {
            _context.TyLe.Remove(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<List<TyLe>> GetAllTyLe()
        {

            return _context.TyLe.ToListAsync();
        }

        public Task<TyLe> GetTyLeById(long id)
        {
            return _context.TyLe.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<TyLe> InsertTyLe(TyLe entity)
        {

            entity.DateCreate = DateTime.Now;
            _context.TyLe.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<TyLe> UpdateTyLe(TyLe entity)
        {
            _context.TyLe.Update(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task<List<TyLe>> GetAllTyLeByMonth(int month)
        {
            return _context.TyLe
                .Where(x=>x.DateCreate.Value.Month== month)
                .ToListAsync();
        }

        public void Insert()
        {
            var tyle = new List<TyLe>();
            tyle.Add(new TyLe()
            {
                Name = "Tiết Kiệm",
                Amount = 20,
                DateCreate= DateTime.Now,
            });
            tyle.Add(new TyLe()
            {
                Name = "Ăn uống",
                Amount = 20,
                DateCreate= DateTime.Now,
            });
            tyle.Add(new TyLe()
            {
                Name = "Mua đồ",
                Amount = 20,
                DateCreate = DateTime.Now,
            });
            tyle.Add(new TyLe()
            {
                Name = "Đi chơi",
                Amount = 10,
                DateCreate = DateTime.Now,
            });
            tyle.Add(new TyLe()
            {
                Name = "Chỗ ở",
                Amount = 20,
                DateCreate = DateTime.Now,
            });
            tyle.Add(new TyLe()
            {
                Name = "Phương tiện",
                Amount = 10,
                DateCreate = DateTime.Now,
            });
            _context.TyLe.AddRange(tyle);
            _context.SaveChanges();
        }
    }
}
