using System;
using System.Collections.Generic;
using System.Text;
using TaiChinh.Core.Entities;

namespace TaiChinh.Core.Interface
{
    public interface ITyLeService
    {
        TyLe InsertTyLe(TyLe entity);
        TyLe UpdateTyLe(TyLe entity);
        TyLe DeleteTyLe(TyLe entity);
        TyLe GetTyLeById(long id);
        List<TyLe> GetAllTyLe();
    }
}
