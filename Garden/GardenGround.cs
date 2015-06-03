using System;
using Server;
using Server.Items;

namespace Server.FarmSystem.Garden
{
    public class GardenGround : BaseAddon
    {
        [Constructable]
        public GardenGround()
        {
            AddComponent(new AddonComponent(0x32C9), -2, 3, 0);
            AddComponent(new AddonComponent(0x32C9), -1, 3, 0);
            AddComponent(new AddonComponent(0x32C9), 0, 3, 0);
            AddComponent(new AddonComponent(0x32C9), 1, 3, 0);
            AddComponent(new AddonComponent(0x32C9), 2, 3, 0);

            AddComponent(new AddonComponent(0x32C9), -2, 2, 0);
            AddComponent(new AddonComponent(0x32C9), -1, 2, 0);
            AddComponent(new AddonComponent(0x32C9), 0, 2, 0);
            AddComponent(new AddonComponent(0x32C9), 1, 2, 0);
            AddComponent(new AddonComponent(0x32C9), 2, 2, 0);

            AddComponent(new AddonComponent(0x32C9), -2, 1, 0);
            AddComponent(new AddonComponent(0x32C9), -1, 1, 0);
            AddComponent(new AddonComponent(0x32C9), 0, 1, 0);
            AddComponent(new AddonComponent(0x32C9), 1, 1, 0);
            AddComponent(new AddonComponent(0x32C9), 2, 1, 0);

            AddComponent(new AddonComponent(0x32C9), -2, 0, 0);
            AddComponent(new AddonComponent(0x32C9), -1, 0, 0);
            AddComponent(new AddonComponent(0x32C9), 0, 0, 0);
            AddComponent(new AddonComponent(0x32C9), 1, 0, 0);
            AddComponent(new AddonComponent(0x32C9), 2, 0, 0);

            AddComponent(new AddonComponent(0x32C9), -2, -1, 0);
            AddComponent(new AddonComponent(0x32C9), -1, -1, 0);
            AddComponent(new AddonComponent(0x32C9), 0, -1, 0);
            AddComponent(new AddonComponent(0x32C9), 1, -1, 0);
            AddComponent(new AddonComponent(0x32C9), 2, -1, 0);
        }

        public GardenGround(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
