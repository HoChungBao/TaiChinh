using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface IChiService
    {
        //Tạo chi
        Task<Chi> InsertChi(Chi entity);
        //Update
        Task<Chi> UpdateChi(Chi entity);
        Task<Chi> DeleteChi(Chi entity);
        Task<Chi> GetChiById(long id);

        //Lấy tất cả tiền chi bao gồm tài khoản, tỉ lệ
        Task<List<Chi>> GetAllChi();

        //Lấy tất cả tiền chi từ ngày đến ngày
        Task<List<Chi>> GetChiFromTo(DateTime dateF, DateTime dateT);
        //Lấy tất cả tiền chi từ tháng
        Task<List<Chi>> GetChiByMonth(int month);
    }
}
