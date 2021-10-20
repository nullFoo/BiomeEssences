using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories.Lesser
{
	public class EssenceLesserCrimson : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Essence of the Crimson");
            Tooltip.SetDefault("Gain buffs in the Crimson");
		}

		public override void SetDefaults() 
		{
			item.accessory = true;
			item.value = 5;
			item.rare = 4;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

			recipe.AddIngredient(ItemID.CrimtaneBar, 10);
            recipe.AddIngredient(ItemID.Vertebrae, 15);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneCrimson)
            {
                player.meleeDamage += 0.05f;
                player.rangedDamage += 0.05f;
                player.minionDamage += 0.05f;
            }
        }
    }
}