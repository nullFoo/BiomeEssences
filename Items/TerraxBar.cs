using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items
{
	public class TerraxBar : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Terrax Bar");
            Tooltip.SetDefault("A powerful combination, smelted to perfection");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 1;
            item.maxStack = 99;

        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.GetItem("Terragem"), 1);
            recipe.AddIngredient(mod.GetItem("TerraxOre"), 4);

            recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}