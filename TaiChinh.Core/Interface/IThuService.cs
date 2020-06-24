using System;
using System.Collections.Generic;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface IThuService
    {
        Thu InsertThu(Thu entity);
        Thu UpdateThu(Thu entity);
        Thu DeleteThu(Thu entity);
        Thu GetThuById(long id);
        List<Thu> GetAllThu();

        //Lấy tất cả tiền thu
        List<Thu> GetThuFromTo(DateTime dateF, DateTime dateT);
    }
}
