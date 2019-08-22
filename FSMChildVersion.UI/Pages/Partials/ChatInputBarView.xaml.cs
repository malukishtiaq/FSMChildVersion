using System;
using System.Collections.Generic;
using FSMChildVersion.Core.ViewModels;
using Xamarin.Forms;

namespace ChatUIXForms.Views.Partials
{
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }
        }
        public void Handle_Completed(object sender, EventArgs e)
        {
            (Parent.Parent.BindingContext as CustomJobsViewModel).OnSendCommand.Execute(null);
            chatTextInput.Focus();
        }

        public void UnFocusEntry(){
            chatTextInput?.Unfocus();
        }

    }
}
