using FSMChildVersion.Core.Model;
using FSMChildVersion.UI.Pages.Cells;
using Xamarin.Forms;

namespace FSMChildVersion.UI.Helpers
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate incomingDataTemplate;
        private readonly DataTemplate outgoingDataTemplate;

        public ChatTemplateSelector()
        {
            incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is MessageModel messageVm))
                return null;


            return (messageVm.User == App.User) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}
