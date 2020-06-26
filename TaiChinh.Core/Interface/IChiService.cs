using System;
using System.Collections.Generic;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface IChiService
    {
        //Tạo chi
        Chi InsertChi(Chi entity);
        Chi UpdateChi(Chi entity);
        Chi DeleteChi(Chi entity);
        Chi GetChiById(long id);

        //Lấy tất cả tiền chi bao gồm tài khoản, tỉ lệ
        List<Chi> GetAllChi();

        //Lấy tất cả tiền chi ngày bao gồm tài khoản, tỉ lệ
        List<Chi> GetChiFromTo(DateTime dateF, DateTime dateT);
    }
}
