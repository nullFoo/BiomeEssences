using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories.Lesser
{
	public class EssenceLesserForest : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Essence of the Forest");
            Tooltip.SetDefault("Gain buffs in the Forest\n" +
                "See better in darkness");
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

			recipe.AddIngredient(ItemID.Wood, 100);
            recipe.AddIngredient(ItemID.DirtBlock, 10);
            recipe.AddIngredient(ItemID.Acorn, 25);
            recipe.AddIngredient(ItemID.Bunny, 1);
            recipe.AddIngredient(ItemID.Squirrel, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneOverworldHeight && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneDesert && !player.ZoneGlowshroom)
            {
                player.statDefense += 3;
                player.AddBuff(BuffID.NightOwl, 2);
                player.AddBuff(BuffID.WellFed, 2);
            }
            /*if (player.ZoneOverworldHeight)
            {
                player.statDefense += 3;
                player.AddBuff(BuffID.NightOwl, 2);
                player.AddBuff(BuffID.WellFed, 2);
            }*/
        }
    }
}