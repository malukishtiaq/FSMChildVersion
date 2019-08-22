using Android.Graphics.Drawables;
using FSMChildVersion.Droid.Rendrer;
using FSMChildVersion.UI.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), target: typeof(ExtendedEntryRenderer))]
namespace FSMChildVersion.Droid.Rendrer
{
    [System.Obsolete]
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
                return;

            UpdateBorders();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null)
                return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
                UpdateBorders();
        }

        private void UpdateBorders()
        {
            var shape = new GradientDrawable();
            shape.SetShape(ShapeType.Rectangle);
            shape.SetCornerRadius(0);

            if (((ExtendedEntry)Element).IsBorderErrorVisible)
            {
                shape.SetStroke(3, ((ExtendedEntry)Element).BorderErrorColor.ToAndroid());
            }
            else
            {
                shape.SetStroke(3, Android.Graphics.Color.LightGray);
                Control.SetBackground(shape);
            }

            Control.SetBackground(shape);
        }

    }
}
