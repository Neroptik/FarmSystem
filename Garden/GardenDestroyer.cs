using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.FarmSystem.Gumps;

namespace Server.FarmSystem.Garden
{
    public class GardenDestroyer : BaseAddon
    {
        [Constructable]
        public GardenDestroyer(GardenFence gardenfence, GardenGround gardenground, Mobile player, GardenVerifier gardenverifier)
        {
            Name = "Destroy garden";
            m_Player = player;
            m_GardenFence = gardenfence;
            m_GardenGround = gardenground;
            m_GardenVerifier = gardenverifier;
            this.ItemID = 3026;
            this.Visible = true;
        }

        private GardenFence m_GardenFence;
        private GardenGround m_GardenGround;
        private Mobile m_Player;
        private GardenVerifier m_GardenVerifier;

        public override void OnDoubleClick(Mobile from)
        {
            if (m_Player == from)
            {
                from.SendGump(new GardenDeleteGump(this, from));
            }
            else
            {
                from.SendMessage("You don't appear to own this garden.");
            }
        }

        public override void OnDelete()
        {
            m_GardenGround.Delete();
            m_GardenFence.Delete();
            m_GardenVerifier.Delete();
            ArrayList crops = CropHelper.GetCropItems(this);
            foreach (Item c in crops)
                c.Delete();
        }

        public GardenDestroyer(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version 
            writer.Write(m_GardenGround);
            writer.Write(m_GardenFence);
            writer.Write(m_Player);
            writer.Write(m_GardenVerifier);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_GardenGround = (GardenGround)reader.ReadItem();
            m_GardenFence = (GardenFence)reader.ReadItem();
            m_Player = (PlayerMobile)reader.ReadMobile();
            m_GardenVerifier = (GardenVerifier)reader.ReadItem();
        }
    }
}
