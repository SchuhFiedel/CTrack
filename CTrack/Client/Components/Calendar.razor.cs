using CTrack.Client.Classes;
using CTrack.Client.Models;
using CTrack.Shared.Models.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Net.Http.Json;

namespace CTrack.Client.Components
{
    public partial class Calendar : AbstractCalendar
    {
        [CascadingParameter(Name = "SelectedView")]
        public DisplayedView DisplayedView { get; set; } = DisplayedView.Monthly;

        private DateTime _firstdate;
        [CascadingParameter(Name = "FirstDate")]
        public DateTime FirstDate
        {
            get
            {
                if (_firstdate == DateTime.MinValue) _firstdate = DateTime.Today;
                return _firstdate.Date;
            }
            set
            {
                _firstdate = value;
            }
        }

        [CascadingParameter(Name = "TasksList")]
        public DTOCalendarEntry[]? TasksList { get; set; }

        [Parameter]
        public PriorityLabel PriorityDisplay { get; set; } = PriorityLabel.Code;

        [Parameter]
        public bool HighlightToday { get; set; } = false;

        [Parameter]
        public EventCallback<int> OutsideCurrentMonthClick { get; set; }

        [Parameter]
        public EventCallback<ClickEmptyDayParameter> DayClick { get; set; }

        [Parameter]
        public EventCallback<ClickTaskParameter> TaskClick { get; set; }

        [Parameter]
        public EventCallback<DragDropParameter> DragStart { get; set; }

        [Parameter]
        public EventCallback<DragDropParameter> DropTask { get; set; }

        private DTOCalendarEntry? TaskDragged;

        private enum StateCase
        {
            Before = 0, // First empty cells part
            InMonth = 1,
            After = 2,
        }

        private async Task HandleClickOutsideCurrentMonthClick(int AddMonth)
        {
            if (OutsideCurrentMonthClick.HasDelegate)
            {
                await OutsideCurrentMonthClick.InvokeAsync(AddMonth);
            }
        }

        private async Task ClickTaskInternal(MouseEventArgs e, Guid taskID, DateTime day)
        {
            if (!TaskClick.HasDelegate) return;

            List<Guid> listID = new()
            {
            taskID
            };

            ClickTaskParameter clickTaskParameter = new()
            {
                IDList = listID,
                X = e.ClientX,
                Y = e.ClientY,
                Day = day
            };

            await TaskClick.InvokeAsync(clickTaskParameter);
        }

        private async Task ClickAllDayInternal(MouseEventArgs e, DateTime day)
        {
            if (day == default) return;

            if (!TaskClick.HasDelegate) return;

            // There can be several tasks in one day :
            List<Guid> listID = new();
            if (TasksList != null)
            {
                for (var k = 0; k < TasksList.Length; k++)
                {
                    DTOCalendarEntry t = TasksList[k];

                    if (t.DateStart.Date <= day.Date && day.Date <= t.DateEnd.Date)
                    {
                        if(t.Id.HasValue)
                            listID.Add(t.Id.Value);
                    }
                }

                ClickTaskParameter clickTaskParameter = new()
                {
                    IDList = listID,
                    X = e.ClientX,
                    Y = e.ClientY,
                    Day = day
                };

                await TaskClick.InvokeAsync(clickTaskParameter);
            }
        }

        private async Task ClickDayInternal(MouseEventArgs e, DateTime day)
        {
            if (!DayClick.HasDelegate) return;

            ClickEmptyDayParameter clickEmptyDayParameter = new()
            {
                Day = day,
                X = e.ClientX,
                Y = e.ClientY
            };

            await DayClick.InvokeAsync(clickEmptyDayParameter);
        }

        private async Task HandleDragStart(Guid taskID)
        {
            TaskDragged = new DTOCalendarEntry()
            {
                Id = taskID
            };

            DragDropParameter dragDropParameter = new()
            {
                taskID = TaskDragged.Id.Value
            };

            await DragStart.InvokeAsync(dragDropParameter);
        }

        private async Task HandleDayOnDrop(DateTime day)
        {
            if (!Draggable) return;
            if (TaskDragged == null) return;

            if (TaskDragged.Id.HasValue)
            {
				DragDropParameter dragDropParameter = new()
				{
					Day = day,
					taskID = TaskDragged.Id.Value
				};

				await DropTask.InvokeAsync(dragDropParameter);
			}

			TaskDragged = null;
        }

        private string GetBackground(DateTime day)
        {
            int d = (int)day.DayOfWeek;

            if (d == 6)
            {
                return $"background:{SaturdayColor}";
            }
            else if (d == 0)
            {
                return $"background:{SundayColor}";
            }

            return $"background:{WeekDaysColor}";
        }
    }
}
