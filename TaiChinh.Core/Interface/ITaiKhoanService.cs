using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface ITaiKhoanService
    {
        //Add
        Task<TaiKhoan> InsertTaiKhoan(TaiKhoan entity);
        Task<TaiKhoan> UpdateTaiKhoan(TaiKhoan entity);
        Task<TaiKhoan> DeleteTaiKhoan(TaiKhoan entity);
        Task<TaiKhoan> GetTaiKhoanById(long id);
        Task<List<TaiKhoan>> GetAllTaiKhoan();

        //Lấy tài khoản bằng id bao gồm tiền thu, chi
        Task<TaiKhoan> GetTaiKhoanThuChiById(long id);

        //Lấy tài khoản bằng id bao gồm tiền thu, chi từ tháng
        Task<TaiKhoan> GetTaiKhoanThuChiByIdDate(long id,int month);

        //Lấy tài khoản bằng id bao gồm tiền thu, chi từ năm
        Task<TaiKhoan> GetTaiKhoanThuChiByIdYear(long id,int year);
    }
}
