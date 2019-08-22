using System;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using MvvmCross;

namespace FSMChildVersion.Common.Helper
{
    public class StaticLocator
    {
        public readonly IUserDialogs UserDialogs;

        public StaticLocator(IUserDialogs userDialogs)
        {
            UserDialogs = userDialogs;
        }
    }
}
