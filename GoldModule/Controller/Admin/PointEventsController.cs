using Gold.Core.Interfaces;
using GoldModule.Models;
using GoldModule.Validators;
using Infrastructure.Extensions.Validators;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoldModule.Admin
{
    public class PointEventsController : Controller
    {
        private readonly IPointEventService _pointEventService;
        public PointEventsController(IPointEventService pointEventService)
        {
            _pointEventService = pointEventService;
        }
        public async Task<IActionResult> Index(string search="",int page=1)
        {
            ViewBag.ViewComponent = NameComponentView.PointEventIndex;
            ViewBag.Page = page;
            ViewBag.Search = search;
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.ViewComponent = NameComponentView.PointEventCreate;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(PointEventPostModel model)
        {
            var rs = new HttpContentResult<dynamic>();
            try
            {
                var pointeventvalidator = new PointEventValidator();
                var validate = pointeventvalidator.Validate(model);
                if (!validate.IsValid)
                {
                    rs.Fail();
                    rs.Message = validate.GetErrorMessageValidator();
                    return Json(rs);
                }

                var point = model.InstanceEntity();
                await _pointEventService.AddAsync(point);
                rs.Success();
                rs.Message = MessageResultJson.Success;
                return Json(rs);
            }
            catch
            {
                return Json(rs);
            }
        }

    }
}
