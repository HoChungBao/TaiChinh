using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface ITyLeService
    {
        Task<TyLe> InsertTyLe(TyLe entity);
        Task<TyLe> UpdateTyLe(TyLe entity);
        Task<TyLe> DeleteTyLe(TyLe entity);
        Task<TyLe> GetTyLeById(long id);
        Task<List<TyLe>> GetAllTyLe();
        Task<List<TyLe>> GetAllTyLeByMonth(int month);

        void Insert();
    }
}
