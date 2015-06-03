using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    class GrowableMandrake : GrowableCrop
    {
        [Constructable]
        public GrowableMandrake()
            : base(CropType.Mandrake)
        {
            
        }

        public GrowableMandrake(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                MandrakeSeed item = new MandrakeSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 mandrake seed.");
            }
            MandrakeRoot c = new MandrakeRoot();
            c.ItemID = 3974;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 mandrake.");
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
