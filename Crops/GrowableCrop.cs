using System;
using System.Collections;
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Multis;


namespace Server.FarmSystem.Crops
{
    public abstract class GrowableCrop : Item
    {
        private CropType m_CropType;
        private int m_NbRessources;
        private int m_HarvestCount;
        private GrowTimer m_GrowTimer;

        public GrowableCrop(CropType cropType)
            : base(CropHelper.GetInfo(cropType).CropId)
        {
            this.Name = CropHelper.GetInfo(cropType).CropName + " seedling";
            this.Movable = false;
            this.m_CropType = cropType;
            this.m_NbRessources = CropHelper.GetInfo(cropType).NbRessources;
            this.m_HarvestCount = CropHelper.GetInfo(cropType).HarvestMax;
            this.m_GrowTimer = new GrowTimer(this, CropHelper.GetInfo(cropType).GrowDuration);
            this.m_GrowTimer.Start();
        }

        public GrowableCrop(Serial serial)
            : base(serial)
        {
        }

        public abstract bool LootItem(Mobile from);

        public override void OnDoubleClick(Mobile from)
        {
            Map map = this.Map;
            Point3D loc = this.Location;

            if (this.Parent != null || this.Movable || this.IsLockedDown || this.IsSecure || map == null || map == Map.Internal)
                return;

            if (!from.InRange(loc, 2) || !from.InLOS(this))
                from.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
            else
                this.Harvest(from);
        }

        public virtual void Harvest(Mobile from)
        {
            if (this.ItemID == CropHelper.GetInfo(this.m_CropType).PlantId)
            {
                if (this.m_NbRessources > 0)
                {
                    if (this.LootItem(from))
                    {
                        this.m_NbRessources--;
                        this.m_HarvestCount--;
                        from.Animate(from.Mounted ? 29 : 32, 5, 1, true, false, 0);
                    }
                    if (this.m_NbRessources == 0)
                    {
                        this.ItemID = CropHelper.GetInfo(this.m_CropType).CropId;
                        this.Name = CropHelper.GetInfo(this.m_CropType).CropName + " seedling";
                    }                        
                    if (this.m_HarvestCount == 0)
                    {
                        from.SendMessage("You accidently uproot all of the " + CropHelper.GetInfo(this.m_CropType).CropName + " plant");
                        this.Delete();
                    }
                }
                else
                {
                    from.SendMessage("There is nothing to harvest!");
                }
                this.m_GrowTimer.Stop();
                this.m_GrowTimer.Start();
            }
            else
            {
                from.SendMessage("This plant is to young to harvest!");
            }
        }

        public void Grow()
        {
            this.ItemID = CropHelper.GetInfo(this.m_CropType).PlantId;
            this.m_NbRessources = CropHelper.GetInfo(this.m_CropType).NbRessources;
            this.Name = CropHelper.GetInfo(this.m_CropType).CropName + " plant";
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.WriteEncodedInt(0); // version
            writer.Write((int)this.m_CropType);
            writer.Write((int)this.m_NbRessources);
            writer.Write((int)this.m_HarvestCount);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadEncodedInt();
            switch (version)
            {
                case 0:
                    this.m_CropType = (CropType)reader.ReadInt();
                    this.m_NbRessources = (int)reader.ReadInt();
                    this.m_HarvestCount = (int)reader.ReadInt();
                    break;
            }
            this.m_GrowTimer = new GrowTimer(this, CropHelper.GetInfo(this.m_CropType).GrowDuration);
            this.m_GrowTimer.Start();
        }

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new MenuEntry(from, this));
            SetSecureLevelEntry.AddTo(from, this, list);
        }

        private class MenuEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Item m_Item;

            public MenuEntry(Mobile from, Item item)
                : base(176)
            {
                m_Mobile = from;
                m_Item = item;
            }

            public override void OnClick()
            {
                if (!this.m_Mobile.InRange(this.m_Item.Location, 2) || !this.m_Mobile.InLOS(this))
                    this.m_Mobile.LocalOverheadMessage(MessageType.Regular, 0x3B2, 1019045); // I can't reach that.
                else
                {
                    this.m_Item.Delete();
                    this.m_Mobile.SendMessage("You uproot the plant!");
                }
            }
        }
    }
}
