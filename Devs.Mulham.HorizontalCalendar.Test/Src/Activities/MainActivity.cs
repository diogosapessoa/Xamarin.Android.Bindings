using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Devs.Mulham.Horizontalcalendar;
using Devs.Mulham.HorizontalCalendar.Test.Utils;
using System;

namespace Devs.Mulham.HorizontalCalendar.Test.Activities
{
    [Activity(
        Label = "@string/app_name",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public HorizontalCalendarClass HorizontalCalendar { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var startDate = Java.Util.Calendar.Instance;
            startDate.Add(Java.Util.CalendarField.Month, -2);

            var endDate = Java.Util.Calendar.Instance;
            endDate.Add(Java.Util.CalendarField.Month, 2);

            var defaultSelectedDate = Java.Util.Calendar.Instance;

            HorizontalCalendar = BuildHorizontalCalendarClass(startDate, endDate, defaultSelectedDate);

            HorizontalCalendar.CalendarListener = new CalendarListener(this);

            FindViewById<Android.Support.Design.Widget.FloatingActionButton>(Resource.Id.fab).Click += FabClick;
        }

        private void FabClick(object sender, EventArgs e)
        {
            HorizontalCalendar.GoToday(false);
        }

        private HorizontalCalendarClass BuildHorizontalCalendarClass(Java.Util.Calendar start, Java.Util.Calendar end, Java.Util.Calendar @default)
        {
            return new HorizontalCalendarClass.Builder(this, Resource.Id.calendarView)
                .Range(start, end)
                .DatesNumberOnScreen(5)
                .Configure()
                .FormatTopText("MMM")
                .FormatMiddleText("dd")
                .FormatBottomText("EEE")
                .ShowTopText(true)
                .ShowBottomText(true)
                .TextColor(Color.LightGray, Color.White)
                .ColorTextMiddle(Color.LightGray, Color.ParseColor("#FF4081"))
                .End()
                .DefaultSelectedDate(@default)
                .Build();
        }
    }
}