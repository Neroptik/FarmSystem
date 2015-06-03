using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    class GrowableGarlic : GrowableCrop
    {
        [Constructable]
        public GrowableGarlic()
            : base(CropType.Garlic)
        {
        }

        public GrowableGarlic(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                GarlicSeed item = new GarlicSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 garlic seed.");
            }
            Garlic c = new Garlic();
            c.ItemID = 3972;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 garlic.");
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
