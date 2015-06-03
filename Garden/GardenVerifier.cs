using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.FarmSystem.Garden
{
    public class GardenVerifier : Item
    {
        [Constructable]
        public GardenVerifier()
            : base(6256)
        {
            Stackable = false;
            Name = "Garden Verifier (ADMIN/GM DO NOT DELETE)";
            Weight = 0;
            Movable = false;
            Visible = false;
        }

        public GardenVerifier(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
