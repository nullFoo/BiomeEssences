using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class OrangeWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Orange Wisp");
            Tooltip.SetDefault("It smells like fire");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}