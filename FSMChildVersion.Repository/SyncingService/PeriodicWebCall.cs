using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
//using Matcha.BackgroundService;

namespace FSMChildVersion.Repository.SyncingService
{
    public class PeriodicWebCall //: IPeriodicTask
    {
        private const int RecallServerAfter = 1; //minutes
        public PeriodicWebCall()
        {
            Interval = TimeSpan.FromMinutes(RecallServerAfter);
        }

        public TimeSpan Interval { get; set; }

        public bool StartJob()
        {
            return true;
        }

        #region DB Modification

        #endregion
    }
}
