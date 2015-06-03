using System;
using Server;
using Server.Items;

namespace Server.FarmSystem.Garden
{
    public class GardenFence : BaseAddon
    {
        [Constructable]
		public GardenFence()
		{
			//East Side
            AddComponent(new AddonComponent(0x7CD), 3, -1, 0);
            AddComponent(new AddonComponent(0x7CD), 3, 0, 0);
            AddComponent(new AddonComponent(0x7CD), 3, 1, 0);
            AddComponent(new AddonComponent(0x7CD), 3, 2, 0);
            AddComponent(new AddonComponent(0x7CD), 3, 3, 0);

			//South Side
			AddComponent( new AddonComponent( 0x7C9 ), 3, 4, 0 ); 
			AddComponent( new AddonComponent( 0x7C9 ), 2, 4, 0 ); 
			AddComponent( new AddonComponent( 0x7C9 ), 1, 4, 0 ); 
			AddComponent( new AddonComponent( 0x7C9 ), 0, 4, 0 );
			AddComponent( new AddonComponent( 0x7C9 ), -1, 4, 0 );  
			AddComponent( new AddonComponent( 0x7C9 ), -2, 4, 0 );			

			//West Side
            AddComponent(new AddonComponent( 0x85F ), -3, -2, 0);
            AddComponent(new AddonComponent( 0x861 ), -3, -1, 0);
            AddComponent(new AddonComponent( 0x861 ), -3, 0, 0);
            AddComponent(new AddonComponent( 0x85E ), -3, 1, 0);
            AddComponent(new AddonComponent( 0x861 ), -3, 2, 0);
            AddComponent(new AddonComponent( 0x861 ), -3, 3, 0);
            AddComponent(new AddonComponent( 0x85E ), -3, 4, 0);
			 
			//North Side
			AddComponent( new AddonComponent( 0x860 ), -2, -2, 0 ); 
			AddComponent( new AddonComponent( 0x860 ), -1, -2, 0 ); 
			AddComponent( new AddonComponent( 0x860 ), 0, -2, 0 );
            AddComponent( new AddonComponent( 0x85F ), 0, -2, 0 );
			AddComponent( new AddonComponent( 0x860 ), 1, -2, 0 ); 
			AddComponent( new AddonComponent( 0x860 ), 2, -2, 0 );
			AddComponent( new AddonComponent( 0x85D ), 3, -2, 0 );
		}

		public GardenFence( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
