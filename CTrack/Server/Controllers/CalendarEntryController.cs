using CTrack.Shared.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using static MudBlazor.CategoryTypes;

namespace CTrack.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarEntryController : ControllerBase
    {
        static List<DTOTag> staticTagList = new List<DTOTag>()
        {
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Free Time"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Work"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Uni"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Sleep"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Social"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Programming"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Reading"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Sports"},
            new(){ BackgroundColor=Color.Red, Description="", Id=Guid.NewGuid(), Name="Cooking/Eating"},
        };

        static List<DTOCalendarEntry> Items = new List<DTOCalendarEntry>()
        {
            new() { DateStart = DateTime.Now.AddHours(5), DateEnd = DateTime.Now.AddHours(5).AddHours(1), Name = "Test+5h"
                , Id=Guid.NewGuid(), TagList=new List<DTOTag>(){ staticTagList[0], staticTagList[4], staticTagList[8]} },
            new() { DateStart = DateTime.Now.AddDays(2), DateEnd = DateTime.Now.AddDays(2).AddHours(1), Name = "Test+2d" 
                , Id=Guid.NewGuid(), TagList=new List<DTOTag>(){ staticTagList[0], staticTagList[3]} },
            new() { DateStart = DateTime.Now.AddDays(5), DateEnd = DateTime.Now.AddDays(5).AddHours(1), Name = "Test+5d" 
                , Id=Guid.NewGuid(), TagList=new List<DTOTag>(){ staticTagList[1] } },
            new() { DateStart = DateTime.Now.AddDays(3), DateEnd = DateTime.Now.AddDays(3).AddHours(1), Name = "Test+3d" 
                , Id=Guid.NewGuid(), TagList=new List<DTOTag>(){ staticTagList[0], staticTagList[2], staticTagList[5]} },
            new() { DateStart = DateTime.Now.AddMonths(1), DateEnd = DateTime.Now.AddMonths(1).AddHours(1),Name = "Test+1m" 
                , Id=Guid.NewGuid(), TagList=new List<DTOTag>(){ staticTagList[0], staticTagList[6]} }
        };

        private readonly ILogger<CalendarEntryController> _logger;

        public CalendarEntryController(ILogger<CalendarEntryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOCalendarEntry>>> Get()
        {
            return Ok(Items);
        }
    }
}