using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableOnion : GrowableCrop
    {
        [Constructable]
        public GrowableOnion()
            : base(CropType.Onion)
        {
        }

        public GrowableOnion(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                OnionSeed item = new OnionSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 onion seed.");
            }
            Onion c = new Onion();
            c.ItemID = 3182;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 onion.");
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