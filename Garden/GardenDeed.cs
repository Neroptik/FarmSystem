using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;
using Server.FarmSystem;

namespace Server.FarmSystem.Garden
{
    public class GardenDeed : Item
    {
        [Constructable]
        public GardenDeed()
            : base(7971)
        {
            Name = "Garden deed";
            Weight = 50.0;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (GardenCheck(from) == false)
            {
                from.SendMessage("You reach the maximum amount of garden.");
            }
            else
            {
                if (IsChildOf(from.Backpack))
                {
                    if (CropHelper.ValidateRegion(from))
                    {
                        GardenFence v = new GardenFence();
                        v.Location = from.Location;
                        v.Map = from.Map;

                        GardenGround y = new GardenGround();
                        y.Location = from.Location;
                        y.Map = from.Map;

                        GardenVerifier gardenverifier = new GardenVerifier();
                        from.AddToBackpack(gardenverifier);
                        
                        GardenDestroyer x = new GardenDestroyer(v, y, from, gardenverifier);
                        x.Location = new Point3D(from.X - 2, from.Y + 4, from.Z - 3);
                        x.Map = from.Map;

                        this.Delete();
                    }
                    else
                    {
                        from.SendMessage("You cannot create your garden in this area!");
                    }
                }
                else
                {
                    from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                }
            }
        }

        public bool GardenCheck(Mobile from)
        {
            int count = 0;
            foreach (Item verifier in from.Backpack.Items)
            {
                if (verifier is GardenVerifier)
                {
                    count = count + 1;
                }
                else
                {
                    count = count + 0;
                }
            }
            if (count > 2) //change this if you want players to own more than 1,2,3 etc.
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public GardenDeed(Serial serial)
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
