using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    class GrowableNightshade : GrowableCrop
    {
        [Constructable]
        public GrowableNightshade()
            : base(CropType.Nightshade)
        {
            
        }

        public GrowableNightshade(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                NightshadeSeed item = new NightshadeSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 nightshade seed.");
            }
            Nightshade c = new Nightshade();
            c.ItemID = 3976;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 nightshade.");
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
