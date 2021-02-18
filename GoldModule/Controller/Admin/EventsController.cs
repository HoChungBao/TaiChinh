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
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string search="",int page=1)
        {
            ViewBag.ViewComponent = NameComponentView.EventIndex;
            ViewBag.Page = page;
            ViewBag.Search = search;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.ViewComponent = NameComponentView.EventCreate;
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(EventPostModel model)
        {
            var rs = new HttpContentResult<dynamic>();
            try
            {
                var eventvalidator = new EventValidator();
                var validate = eventvalidator.Validate(model);
                if (!validate.IsValid)
                {
                    rs.Fail();
                    rs.Message = validate.GetErrorMessageValidator();
                    return Json(rs);
                }

                var eventmodel = model.InstanceEntity();
               await  _eventService.AddAsync(eventmodel);
                rs.Success();
                rs.Message = MessageResultJson.Success;
                return Json(rs);
            }
            catch(Exception ex)
            {
                return Json(rs);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ChartDay(DateTime datefrom,DateTime dateto)
        {
            ViewBag.DateFrom = datefrom;
            ViewBag.DateTo = dateto;
            return View();
        }
        /// <summary>
        /// Biểu đồ tuần của một tháng
        /// </summary>
        /// <param name="datefrom">tuần của tháng này</param>
        /// <returns>Biểu đồ hiển thị dữ liệu tăng giảm giá vàng</returns>
        [HttpGet]
        public async Task<IActionResult> ChartWeeky(DateTime datefrom)
        {
            //Ngày đầu của tháng
            ViewBag.DateFrom = datefrom;
            //Ngày cuối của tháng
            ViewBag.DateTo = datefrom.DayOfWeek;
            return View();
        }

    }
}
