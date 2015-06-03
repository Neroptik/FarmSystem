using System;
using Server.Items;
using Server.FarmSystem.Seeds;

namespace Server.FarmSystem.Crops
{
    class GrowableBloodmoss : GrowableCrop
    {
        [Constructable]
        public GrowableBloodmoss()
            : base(CropType.Bloodmoss)
        {
            this.Hue = CropHelper.GetInfo(CropType.Bloodmoss).CropHue;
        }

        public GrowableBloodmoss(Serial serial)
            : base(serial)
        {
        }

        public override bool LootItem(Mobile from)
        {
            if (Utility.RandomDouble() <= .05)
            {
                BloodmossSeed item = new BloodmossSeed();
                from.AddToBackpack(item);
                from.SendMessage("You manage to gather 1 bloodmoss seed.");
            }
            Bloodmoss c = new Bloodmoss();
            c.ItemID = 3963;
            from.AddToBackpack(c);
            from.SendMessage("You manage to gather 1 bloodmoss.");
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
