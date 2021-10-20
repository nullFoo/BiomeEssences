using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class RedWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Red Wisp");
            Tooltip.SetDefault("It smells like flesh and ichor");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}