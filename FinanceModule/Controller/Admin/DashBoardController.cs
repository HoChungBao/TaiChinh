using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaiChinh.Core.Interface;

namespace FinanceModule.Admin
{
    public class DashBoardController : Controller
    {
        private readonly IThuService _thuService;
        private readonly IChiService _chiService;
        private readonly ITaiKhoanService _taiKhoanService;
        private readonly ITyLeService _tyLeService;
        public DashBoardController(ITaiKhoanService taiKhoanService, ITyLeService tyLeService, IThuService thuService, IChiService chiService)
        {
            _thuService = thuService;
            _chiService = chiService;
            _taiKhoanService = taiKhoanService;
            _tyLeService = tyLeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
