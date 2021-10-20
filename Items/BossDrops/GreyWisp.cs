using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class GreyWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Grey Wisp");
            Tooltip.SetDefault("It smells like dirt and rocks");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}