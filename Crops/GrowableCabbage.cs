using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableCabbage : GrowableCrop
    {
        [Constructable]
        public GrowableCabbage()
            : base(CropType.Cabbage)
        {
        }

        public GrowableCabbage(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                CabbageSeed item = new CabbageSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 cabbage seed.");
            }
            Cabbage c = new Cabbage();
            c.ItemID = 3195;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 cabbage.");
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