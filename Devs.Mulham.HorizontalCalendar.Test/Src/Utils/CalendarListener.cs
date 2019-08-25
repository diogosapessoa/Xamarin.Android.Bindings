using Android.Content;
using Android.Text.Format;
using Android.Widget;
using Devs.Mulham.Horizontalcalendar.Utils;

namespace Devs.Mulham.HorizontalCalendar.Test.Utils
{
    public class CalendarListener : HorizontalCalendarListener
    {
        public Context Context { get; }
        public CalendarListener(Context context) : base()
        {
            Context = context;
        }

        public override void OnDateSelected(Java.Util.Calendar date, int position)
        {
            var selectedDateStr = DateFormat.Format("EEE, MMM d, yyyy", date).ToString();
            Toast.MakeText(Context, selectedDateStr + " selected!", ToastLength.Long).Show();
        }
    }
}