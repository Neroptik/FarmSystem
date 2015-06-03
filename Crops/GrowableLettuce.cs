using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableLettuce : GrowableCrop
    {
        [Constructable]
        public GrowableLettuce()
            : base(CropType.Lettuce)
        {
        }

        public GrowableLettuce(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                LettuceSeed item = new LettuceSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 lettuce seed.");
            }
            Lettuce c = new Lettuce();
            c.ItemID = 3184;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 lettuce.");
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