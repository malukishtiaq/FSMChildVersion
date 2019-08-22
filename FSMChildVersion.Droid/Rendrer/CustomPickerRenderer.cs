using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using FSMChildVersion.Droid.Rendrer;
using FSMChildVersion.UI.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), target: typeof(CustomPickerRenderer))]
namespace FSMChildVersion.Droid.Rendrer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        private CustomPicker element;

        public CustomPickerRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)Element;
            if (element is null)
                return;

            if (Control != null && Element != null && !string.IsNullOrEmpty(element?.Image))
                Control.Background = AddPickerStyles(element.Image);

        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {
            var border = new ShapeDrawable();
            border.Paint.Color = Android.Graphics.Color.Gray;
            border.SetPadding(10, 10, 10, 10);
            border.Paint.SetStyle(Paint.Style.Stroke);

            Drawable[] layers = { border, GetDrawable(imagePath) };
            var layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 0, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            var resID = Resources.GetIdentifier(imagePath, "drawable", Context.PackageName);
            Drawable drawable = ContextCompat.GetDrawable(Context, resID);
            Bitmap bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 35, 35, true))
            {
                Gravity = Android.Views.GravityFlags.Right
            };

            return result;
        }

    }
}
