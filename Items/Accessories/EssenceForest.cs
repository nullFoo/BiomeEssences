using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceForest : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Forest");
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


            recipe.AddIngredient(mod.GetItem("EssenceLesserForest"), 1);
            recipe.AddIngredient(mod.GetItem("BrownWisp"), 1);

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
        }
    }
}