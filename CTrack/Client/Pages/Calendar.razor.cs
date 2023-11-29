using CTrack.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace CTrack.Client.Pages
{
    public partial class Calendar
    {
        [Inject] HttpClient Http { get; set; } = null;

        string monthName = null!;
        int numDummyCol = 0;
        DateTime monthEnd;
        DateTime monthStart;
        int CurrentMonth;
        int CurrentYear;
        int MonthCounter = 0;

        List<DTOCalendarEntry> Items = new List<DTOCalendarEntry>();

        protected override async Task OnInitializedAsync()
        {

            var result = await Http.GetAsync("CalendarEntry");
            var tmpList = (await result.Content.ReadFromJsonAsync<IEnumerable<DTOCalendarEntry>>(Program.defaultJsonSerializerOptions))?.ToList();
            Console.WriteLine(String.Join(Environment.NewLine, tmpList));
            this.Items = tmpList;
            CreateMonth();
            base.OnInitialized();
        }


        void CreateMonth()
        {
            DateTime tempDate = DateTime.Now.AddMonths(MonthCounter);
            CurrentMonth = tempDate.Month;
            CurrentYear = tempDate.Year;

            monthStart = new DateTime(CurrentYear, CurrentMonth, 1);
            monthEnd = monthStart.AddMonths(1).AddDays(-1);

            monthName = monthStart.Month switch
            {
                1 => "January",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "Autust",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => "ERROR"
            };

            numDummyCol = ((int)monthStart.DayOfWeek) - 1;
        }
    }
}
