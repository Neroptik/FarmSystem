using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableCotton : GrowableCrop
    {
        [Constructable]
        public GrowableCotton()
            : base(CropType.Cotton)
        {
        }

        public GrowableCotton(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                CottonSeed item = new CottonSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 cotton seed.");
            }
            Cotton c = new Cotton();
            c.ItemID = 3577;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 cotton crop.");
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