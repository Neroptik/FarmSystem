using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableCarrot : GrowableCrop
    {
        [Constructable]
        public GrowableCarrot()
            : base(CropType.Carrot)
        {
        }

        public GrowableCarrot(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                CarrotSeed item = new CarrotSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 carrot seed.");
            }
            Carrot c = new Carrot();
            c.ItemID = 3191;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 carrot.");
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