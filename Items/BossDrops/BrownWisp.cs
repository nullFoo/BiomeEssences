using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class BrownWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Brown Wisp");
            Tooltip.SetDefault("It smells like wood");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}