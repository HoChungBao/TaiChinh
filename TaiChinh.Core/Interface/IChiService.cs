using System;
using System.Collections.Generic;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface IChiService
    {
        Chi InsertChi(Chi entity);
        Chi UpdateChi(Chi entity);
        Chi DeleteChi(Chi entity);
        Chi GetChiById(long id);
        List<Chi> GetAllChi();
        //Lấy tất cả tiền chi
        List<Chi> GetChiFromTo(DateTime dateF, DateTime dateT);
    }
}
