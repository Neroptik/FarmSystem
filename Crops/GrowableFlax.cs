using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableFlax : GrowableCrop
    {
        [Constructable]
        public GrowableFlax()
            : base(CropType.Flax)
        {
        }

        public GrowableFlax(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                FlaxSeed item = new FlaxSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 flax seed.");
            }
            Flax c = new Flax();
            c.ItemID = 6812;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 flax bundle.");
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