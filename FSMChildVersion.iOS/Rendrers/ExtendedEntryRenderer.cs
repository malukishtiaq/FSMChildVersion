using System;
using FSMChildVersion.iOS.Rendrers;
using FSMChildVersion.UI.CustomControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace FSMChildVersion.iOS.Rendrers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control == null || Element == null)
                return;

            if (e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)
            {
                if (((ExtendedEntry)Element).IsBorderErrorVisible)
                {
                    Control.Layer.BorderColor = ((ExtendedEntry)Element).BorderErrorColor.ToCGColor();
                    Control.Layer.BorderWidth = new nfloat(0.8);
                    Control.Layer.CornerRadius = 5;
                }
                else
                {
                    Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                    Control.Layer.CornerRadius = 5;
                    Control.Layer.BorderWidth = new nfloat(0.8);
                }

            }
        }

    }
}
