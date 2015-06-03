using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    class GrowableGinseng : GrowableCrop
    {
        [Constructable]
        public GrowableGinseng()
            : base(CropType.Ginseng)
        {
            
        }

        public GrowableGinseng(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                GinsengSeed item = new GinsengSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 ginseng seed.");
            }
            Ginseng c = new Ginseng();
            c.ItemID = 3973;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 ginseng.");
            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
