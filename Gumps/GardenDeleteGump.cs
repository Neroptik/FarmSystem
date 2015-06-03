using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.FarmSystem.Garden;

namespace Server.FarmSystem.Gumps
{
    public class GardenDeleteGump : Gump
    {
        public GardenDeleteGump(GardenDestroyer gardendestroyer, Mobile owner)
            : base(150, 75)
        {
            m_GardenDestroyer = gardendestroyer;
            owner.CloseGump(typeof(GardenDeleteGump));
            this.Closable = false;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(0, 0, 300, 120, 9200);
            this.AddBackground(10, 10, 280, 100, 3500);
            this.AddLabel(30, 30, 0, @"Do you want to destroy your garden?");
            this.AddButton(100, 66, 4023, 4024, 1, GumpButtonType.Reply, 0);
            this.AddButton(160, 66, 4017, 4018, 0, GumpButtonType.Reply, 0);
        }

        private GardenDestroyer m_GardenDestroyer;

        public override void OnResponse(NetState state, RelayInfo info) //Function for GumpButtonType.Reply Buttons 
        {
            Mobile from = state.Mobile;
            switch (info.ButtonID)
            {
                case 0:
                    from.SendMessage("Your choose not to destroy your garden.");
                    break;
                
                case 1:
                    m_GardenDestroyer.Delete();
                    from.AddToBackpack(new GardenDeed());
                    from.SendMessage("You destroyed your garden, and placed the creation tool back in your backpack.");
                    break;
            }
        }
    }
}
