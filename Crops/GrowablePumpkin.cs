using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowablePumpkin : GrowableCrop
    {
        [Constructable]
        public GrowablePumpkin()
            : base(CropType.Pumpkin)
        {
        }

        public GrowablePumpkin(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                PumpkinSeed item = new PumpkinSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 pumpkin seed.");
            }
            Pumpkin c = new Pumpkin();
            c.ItemID = 3178;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 pumpkin.");
            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}