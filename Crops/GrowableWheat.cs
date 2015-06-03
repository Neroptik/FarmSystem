using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableWheat : GrowableCrop
    {
        [Constructable]
        public GrowableWheat()
            : base(CropType.Wheat)
        {
        }

        public GrowableWheat(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                WheatSeed item = new WheatSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 wheat seed.");
            }
            WheatSheaf c = new WheatSheaf();
            c.ItemID = 7869;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 wheat sheaf.");
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