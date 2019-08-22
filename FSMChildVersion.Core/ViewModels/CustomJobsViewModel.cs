using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FSMChildVersion.Core.Model;
using Xamarin.Forms;

namespace FSMChildVersion.Core.ViewModels
{
    public class CustomJobsViewModel : BaseViewModel
    {
        private string textToSend;

        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<MessageModel> DelayedMessages { get; set; } = new Queue<MessageModel>();
        public ObservableCollection<MessageModel> Messages { get; set; } = new ObservableCollection<MessageModel>();
        public string TextToSend
        {
            get => textToSend;
            set
            {
                if (textToSend == value)
                    return;
                textToSend = value;

                RaisePropertyChanged(() => TextToSend);
            }
        }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }


        public CustomJobsViewModel()
        {
            Messages.Insert(0, new MessageModel() { Text = "Hi" });
            Messages.Insert(0, new MessageModel() { Text = "How are you?", User = App.User });
            Messages.Insert(0, new MessageModel() { Text = "Oh My God!" });

            MessageAppearingCommand = new Command<MessageModel>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<MessageModel>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Insert(0, new MessageModel() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }

            });

            ////Code to simulate reveing a new message procces
            //Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            //{
            //    if (LastMessageVisible)
            //    {
            //        Messages.Insert(0, new MessageModel() { Text = "New message test", User = "Mario" });
            //    }
            //    else
            //    {
            //        DelayedMessages.Enqueue(new MessageModel() { Text = "New message test", User = "Mario" });
            //        PendingMessageCount++;
            //    }
            //    return true;
            //});



        }

        void OnMessageAppearing(MessageModel message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(MessageModel message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
