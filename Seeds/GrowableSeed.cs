using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.FarmSystem.Crops;

namespace Server.FarmSystem.Seeds
{
    class GrowableSeed : Item
    {
        private CropType m_CropType;

        [Constructable]
        public GrowableSeed()
            : this(CropType.Flax)
        {
        }

        [Constructable]
        public GrowableSeed(CropType cropType)
            : base(0xDCF)
        {
            this.Weight = 1.0;
            this.Stackable = Core.SA;
            this.Name = CropHelper.GetInfo(cropType).CropName + " seed";
            this.Hue = CropHelper.GetInfo(cropType).CropHue;
            this.m_CropType = cropType;
        }

        public GrowableSeed(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public CropType CropType
        {
            get
            {
                return this.m_CropType;
            }
            set
            {
                this.m_CropType = value;
                this.InvalidateProperties();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1060810; // seed
            }
        }

        public override bool ForceShowProperties
        {
            get
            {
                return ObjectPropertyList.Enabled;
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            Point3D m_pnt = from.Location;
            Map m_map = from.Map;

            if (CropHelper.ValidateGardenGround(m_map, m_pnt.X, m_pnt.Y))
            {
                if (CropHelper.ValidateNoCrop(m_map, m_pnt.X, m_pnt.Y))
                {
                    if (!this.IsChildOf(from.Backpack))
                    {
                        from.SendLocalizedMessage(1042664); // You must have the object in your backpack to use it.
                        return;
                    }

                    GrowableCrop crop = CropHelper.GetInfo(m_CropType).CropItem;
                    from.Animate(from.Mounted ? 29 : 32, 5, 1, true, false, 0);
                    crop.Location = m_pnt;
                    crop.Z = crop.Z + 1;
                    crop.Map = m_map;
                    from.SendMessage("You manage to plant a " + this.Name);
                    if (this.Amount > 1)
                        this.Amount--;
                    else
                        this.Delete();
                }
                else
                {
                    from.SendMessage("There already is a seed here!");
                }
            }
            else
            {
                from.SendMessage("You must be in a garden to plant the seed!");
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
            writer.Write((int)this.m_CropType);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            this.m_CropType = (CropType)reader.ReadInt();
            
            if (this.Weight != 1.0)
                this.Weight = 1.0;

            if (version < 1)
                this.Stackable = Core.SA;
        }
    }
}
