using Android.Content;
using Android.Graphics.Drawables;
using Mobile.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer_Droid))]
namespace Mobile.Droid.Renderers
{
    public class CustomEntryRenderer_Droid : EntryRenderer
    {
        public CustomEntryRenderer_Droid(Context context) : base(context)
        {
            AutoPackage = false;

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }

    public class CustomTimePickerRenderer_Droid : TimePickerRenderer
    {
        public CustomTimePickerRenderer_Droid(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);


            var gd = new GradientDrawable();
            gd.SetStroke(0, Android.Graphics.Color.Transparent);
            Control.SetBackground(gd);
        }
    }
}