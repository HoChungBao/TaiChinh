using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface IThuService
    {
        //Add
        Task<Thu> InsertThu(Thu entity);
        //Update
        Task<Thu> UpdateThu(Thu entity);
        //Delete
        Task<Thu> DeleteThu(Thu entity);
        //Lấy tiền thu băng id
        Task<Thu> GetThuById(long id);
        //Lấy tất cả tiền thu bao gôm tài khoản
        Task<List<Thu>> GetAllThu();
        //Lấy tất cả tiền thu từ ngày đến ngày
        Task<List<Thu>> GetThuFromTo(DateTime dateF, DateTime dateT);
        //Lấy tất cả tiền thu từ tháng
        Task<List<Thu>> GetThuByMonth(int month);

    }
}
