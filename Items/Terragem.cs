using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items
{
	public class Terragem : ModItem
	{
		public override void SetStaticDefaults() 
		{
            DisplayName.SetDefault("Terragem");
            Tooltip.SetDefault("Made of all the gems of the depths");
		}

		public override void SetDefaults() 
		{
			item.value = 1;
			item.rare = 2;
            item.maxStack = 99;

        }

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddIngredient(ItemID.Emerald, 1);
            recipe.AddIngredient(ItemID.Topaz, 1);
            recipe.AddIngredient(ItemID.Amethyst, 1);
            recipe.AddIngredient(ItemID.Diamond, 1);

            recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}