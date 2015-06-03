﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.FarmSystem.Seeds
{
    class CabbageSeed : GrowableSeed
    {
        [Constructable]
        public CabbageSeed()
            : base(CropType.Cabbage)
        {
        }

        public CabbageSeed(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
    }
}
