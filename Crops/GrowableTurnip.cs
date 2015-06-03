using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    public class GrowableTurnip : GrowableCrop
    {
        [Constructable]
        public GrowableTurnip()
            : base(CropType.Turnip)
        {
        }

        public GrowableTurnip(Serial serial)
            : base(serial)
        {
        }
        
        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                TurnipSeed item = new TurnipSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 turnip seed.");
            }
            Turnip c = new Turnip();
            c.ItemID = 3385;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 turnip.");
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