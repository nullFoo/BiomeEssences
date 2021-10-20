using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class BlueWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Blue Wisp");
            Tooltip.SetDefault("It smells like the sea");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}