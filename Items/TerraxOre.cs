using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items
{
	public class TerraxOre : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Terrax Ore");
            Tooltip.SetDefault("A powerful combination");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 1;
            item.maxStack = 999;

        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.IronOre, 1);
            recipe.AddIngredient(ItemID.LeadOre, 1);
            recipe.AddIngredient(ItemID.GoldOre, 1);
            recipe.AddIngredient(ItemID.SilverOre, 1);
            recipe.AddIngredient(ItemID.PlatinumOre, 1);
            recipe.AddIngredient(ItemID.TungstenOre, 1);
            recipe.AddIngredient(ItemID.TinOre, 1);

            recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}