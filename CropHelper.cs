using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Server.FarmSystem.Crops;

namespace Server.FarmSystem
{
    public enum CropType
    {
        Cabbage,
        Carrot,
        Cotton,
        Flax,
        Lettuce,
        Onion,
        Pumpkin,
        Turnip,
        Wheat,
        Bloodmoss,
        Garlic,
        Ginseng,
        Mandrake,
        Nightshade
    }

    public class CropHelper
    {
        private static readonly CropHelper[] m_Table = new CropHelper[]
        {
            //             CropType             CropName      CropHue CropId  PlanId  GrowDuration    NbRess  HarvestMax
            new CropHelper(CropType.Cabbage,    "cabbage",    0x8A4,  3169,   3196,   14400,          1,      500),
            new CropHelper(CropType.Carrot,     "carrot",     0x7E0,  3176,   3190,   14400,          2,      500),
            new CropHelper(CropType.Cotton,     "cotton",     0x76C,  3153,   3151,   14400,          3,      500),
            new CropHelper(CropType.Flax,       "flax",       0x57C,  6809,   6811,   14400,          4,      500),
            new CropHelper(CropType.Lettuce,    "lettuce",    0x7D3,  3169,   3185,   14400,          1,      500),
            new CropHelper(CropType.Onion,      "onion",      0x7D7,  3176,   3183,   14400,          3,      500),
            new CropHelper(CropType.Pumpkin,    "pumpkin",    0x842,  3167,   3178,   14400,          1,      500),
            new CropHelper(CropType.Turnip,     "turnip",     0x7DD,  3169,   3171,   14400,          3,      500),
            new CropHelper(CropType.Wheat,      "wheat",      0x84D,  3157,   3160,   14400,          5,      500),
            new CropHelper(CropType.Bloodmoss,  "bloodmoss",  0x846,  3342,   3348,   14400,          4,      500),
            new CropHelper(CropType.Garlic,     "garlic",     0x3BC,  3176,   6369,   14400,          4,      500),
            new CropHelper(CropType.Ginseng,    "ginseng",    0x456,  3254,   6377,   14400,          4,      500),
            new CropHelper(CropType.Mandrake,   "mandrake",   0x45D,  6367,   6368,   14400,          4,      500),
            new CropHelper(CropType.Nightshade, "nightshade", 0x23D,  3254,   6373,   14400,          4,      500)
        };

        private readonly CropType m_CropType;
        private readonly String m_CropName;
        private readonly int m_CropHue;
        private readonly int m_CropId;
        private readonly int m_PlantId;
        private readonly int m_GrowDuration;
        private readonly int m_NbRessources;
        private readonly int m_HarvestMax;

        private CropHelper(CropType cropType, String cropName, int cropHue, int cropId, int plantId, int growDuration, int nbRessources, int harvestMax)
        {
            this.m_CropType = cropType;
            this.m_CropName = cropName;
            this.m_CropHue = cropHue;
            this.m_CropId = cropId;
            this.m_PlantId = plantId;
            this.m_GrowDuration = growDuration;
            this.m_NbRessources = nbRessources;
            this.m_HarvestMax = harvestMax;
        }

        public static CropHelper GetInfo(CropType plantType)
        {
            int index = (int)plantType;

            if (index >= 0 && index < m_Table.Length)
                return m_Table[index];
            else
                return m_Table[0];
        }

        public CropType CropType
        {
            get
            {
                return this.m_CropType;
            }
        }

        public String CropName
        {
            get
            {
                return this.m_CropName;
            }
        }

        public int CropHue
        {
            get
            {
                return this.m_CropHue;
            }
        }

        public int CropId
        {
            get
            {
                return this.m_CropId;
            }
        }

        public int PlantId
        {
            get
            {
                return this.m_PlantId;
            }
        }

        public int GrowDuration
        {
            get
            {
                return this.m_GrowDuration;
            }
        }

        public int NbRessources
        {
            get
            {
                return this.m_NbRessources;
            }
        }

        public int HarvestMax
        {
            get
            {
                return this.m_HarvestMax;
            }
        }

        public GrowableCrop CropItem
        {
            get
            {
                switch (this.m_CropType)
                {
                    case CropType.Cabbage:
                        return new GrowableCabbage();
                    case CropType.Carrot:
                        return new GrowableCarrot();
                    case CropType.Cotton:
                        return new GrowableCotton();
                    case CropType.Flax:
                        return new GrowableFlax();
                    case CropType.Lettuce:
                        return new GrowableLettuce();
                    case CropType.Onion:
                        return new GrowableOnion();
                    case CropType.Pumpkin:
                        return new GrowablePumpkin();
                    case CropType.Turnip:
                        return new GrowableTurnip();
                    case CropType.Wheat:
                        return new GrowableWheat();
                    case CropType.Bloodmoss:
                        return new GrowableBloodmoss();
                    case CropType.Garlic:
                        return new GrowableGarlic();
                    case CropType.Mandrake:
                        return new GrowableMandrake();
                    case CropType.Ginseng:
                        return new GrowableGinseng();
                    case CropType.Nightshade:
                        return new GrowableNightshade();
                    default:
                        return new GrowableFlax();
                }
            }
        }

        public static bool ValidateGardenGround(Map map, int x, int y)
        {
            IPooledEnumerable<Item> items = map.GetItemsInBounds(new Rectangle2D(x, y, 1, 1));
            foreach (Item i in items)
            {
                if (i.ItemID == 13001)
                    return true;
            }
            return false;
        }

        public static bool ValidateNoCrop(Map map, int x, int y)
        {
            IPooledEnumerable<Item> items = map.GetItemsInBounds(new Rectangle2D(x, y, 1, 1));
            foreach (Item i in items)
            {
                for (int index = 0; index < m_Table.Length; index++ )
                {
                    if (m_Table[index].CropId == i.ItemID || m_Table[index].PlantId == i.ItemID)
                        return false;
                }
            }
            return true;
        }

        public static ArrayList GetCropItems(Item gardenDestroyer)
        {
            ArrayList crops = new ArrayList();
            Point3D m_pnt = gardenDestroyer.Location;
            Map m_map = gardenDestroyer.Map;
            IPooledEnumerable<Item> items = m_map.GetItemsInBounds(new Rectangle2D(m_pnt.X, m_pnt.Y - 5, 5, 5));
            foreach (Item i in items)
            {
                for (int index = 0; index < m_Table.Length; index++ )
                {
                    if ((m_Table[index].CropId == i.ItemID || m_Table[index].PlantId == i.ItemID) && i.Movable == false)
                        crops.Add(i);
                }
            }
            return crops;
        }

        public static bool ValidateRegion(Mobile from)
        {
            if (from.Region.Name != "Cove" && from.Region.Name != "Britain" &&//towns
               from.Region.Name != "Jhelom" && from.Region.Name != "Minoc" &&//towns
               from.Region.Name != "Haven" && from.Region.Name != "Trinsic" &&//towns
               from.Region.Name != "Vesper" && from.Region.Name != "Yew" &&//towns
               from.Region.Name != "Wind" && from.Region.Name != "Serpent's Hold" &&//towns
               from.Region.Name != "Skara Brae" && from.Region.Name != "Nujel'm" &&//towns
               from.Region.Name != "Moonglow" && from.Region.Name != "Magincia" &&//towns
               from.Region.Name != "Delucia" && from.Region.Name != "Papua" &&//towns
               from.Region.Name != "Buccaneer's Den" && from.Region.Name != "Ocllo" &&//towns
               from.Region.Name != "Gargoyle City" && from.Region.Name != "Mistas" &&//towns
               from.Region.Name != "Montor" && from.Region.Name != "Alexandretta's Bowl" &&//towns
               from.Region.Name != "Lenmir Anfinmotas" && from.Region.Name != "Reg Volon" &&//towns
               from.Region.Name != "Bet-Lem Reg" && from.Region.Name != "Lake Shire" &&//towns
               from.Region.Name != "Ancient Citadel" && from.Region.Name != "Luna" &&//towns
               from.Region.Name != "Umbra" && //towns

               from.Region.Name != "Moongates" &&

               from.Region.Name != "Covetous" && from.Region.Name != "Deceit" &&//dungeons
               from.Region.Name != "Despise" && from.Region.Name != "Destard" &&//dungeons
               from.Region.Name != "Hythloth" && from.Region.Name != "Shame" &&//dungeons
               from.Region.Name != "Wrong" && from.Region.Name != "Terathan Keep" &&//dungeons
               from.Region.Name != "Fire" && from.Region.Name != "Ice" &&//dungeons
               from.Region.Name != "Rock Dungeon" && from.Region.Name != "Spider Cave" &&//dungeons
               from.Region.Name != "Spectre Dungeon" && from.Region.Name != "Blood Dungeon" &&//dungeons
               from.Region.Name != "Wisp Dungeon" && from.Region.Name != "Ankh Dungeon" &&//dungeons
               from.Region.Name != "Exodus Dungeon" && from.Region.Name != "Sorcerer's Dungeon" &&//dungeons
               from.Region.Name != "Ancient Lair" && from.Region.Name != "Doom" &&//dungeons

               from.Region.Name != "Britain Graveyard" && from.Region.Name != "Wrong Entrance" &&
               from.Region.Name != "Covetous Entrance" && from.Region.Name != "Despise Entrance" &&
               from.Region.Name != "Despise Passage" && from.Region.Name != "Jhelom Islands" &&
               from.Region.Name != "Haven Island" && from.Region.Name != "Crystal Cave Entrance" &&
               from.Region.Name != "Protected Island" && from.Region.Name != "Jail")
            {
                Point3D m_pnt = from.Location;
                Map m_map = from.Map;
                int startx = m_pnt.X - 3;
                int starty = m_pnt.Y - 2;
                int z = m_pnt.Z;
                // No locked items in the region
                IPooledEnumerable<Item> items = m_map.GetItemsInBounds(new Rectangle2D(startx, starty, 8, 8));
                foreach (Item i in items)
                {
                    if (i.Movable == false)
                    {
                        return false;
                    }
                }
                // Only grass on region and same Z offset
                for (int x = startx; x < startx + 8; x++)
                {
                    for (int y = starty; y < starty + 8; y++)
                    {
                        LandTile tile = m_map.Tiles.GetLandTile(x, y);
                        if (tile.ID < 3 || tile.ID > 6 || tile.Z != z)
                            return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
