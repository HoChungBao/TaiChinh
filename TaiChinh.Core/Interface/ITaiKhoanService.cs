using System;
using System.Collections.Generic;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface ITaiKhoanService
    {
        TaiKhoan InsertTaiKhoan(TaiKhoan entity);
        TaiKhoan UpdateTaiKhoan(TaiKhoan entity);
        TaiKhoan DeleteTaiKhoan(TaiKhoan entity);
        TaiKhoan GetTaiKhoanById(long id);
        List<TaiKhoan> GetAllTaiKhoan();
    }
}
