using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.FarmSystem.Crops;

namespace Server.FarmSystem
{
    public class GrowTimer : Timer
    {
        private GrowableCrop crop;

        public GrowTimer(GrowableCrop c, int timespan)
            : base(TimeSpan.FromSeconds(timespan), TimeSpan.FromSeconds(timespan))
        {
            crop = c;
            Priority = TimerPriority.OneSecond;
        }

        protected override void OnTick()
        {
            if (crop == null || crop.Deleted)
            {
                Stop();
                return;
            }
            crop.Grow();
        }
    }
}
