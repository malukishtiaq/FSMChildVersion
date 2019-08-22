using Xamarin.Forms;

namespace FSMChildVersion.UI.CustomControls
{
    public class ExtendedEntry : Entry
    {
        public static readonly BindableProperty IsBorderErrorVisibleProperty =
            BindableProperty.Create(nameof(IsBorderErrorVisible), typeof(bool), typeof(ExtendedEntry), false, BindingMode.TwoWay);

        public bool IsBorderErrorVisible
        {
            get => (bool)GetValue(IsBorderErrorVisibleProperty);
            set => SetValue(IsBorderErrorVisibleProperty, value);
        }

        public static readonly BindableProperty BorderErrorColorProperty =
            BindableProperty.Create(nameof(BorderErrorColor), typeof(Xamarin.Forms.Color), typeof(ExtendedEntry), Xamarin.Forms.Color.Transparent, BindingMode.TwoWay);

        public Xamarin.Forms.Color BorderErrorColor
        {
            get => (Color)GetValue(BorderErrorColorProperty);
            set => SetValue(BorderErrorColorProperty, value);
        }

        public static readonly BindableProperty ErrorTextProperty =
        BindableProperty.Create(nameof(ErrorText), typeof(string), typeof(ExtendedEntry), string.Empty);

        public string ErrorText
        {
            get => (string)GetValue(ErrorTextProperty);
            set => SetValue(ErrorTextProperty, value);
        }
    }
}
