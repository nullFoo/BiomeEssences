using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.BossDrops
{
	public class WhiteWisp : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("White Wisp");
            Tooltip.SetDefault("It smells like ice");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;
        }
	}
}