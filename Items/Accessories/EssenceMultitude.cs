using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceMultitude : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Multitudes");
            Tooltip.SetDefault("The diverse biomes and types of land" +
                "Gives the effects of the Essences of the Ocean, Desert, Jungle and Snow");
        }

		public override void SetDefaults() 
		{
			item.accessory = true;
			item.value = 25;
			item.rare = 8;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.GetItem("EssenceOcean"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceDesert"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceJungle"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceSnow"), 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneSnow || player.ZoneBeach || player.ZoneJungle || player.ZoneDesert || player.adjWater)
            {
                player.AddBuff(BuffID.Flipper, 2);
                player.AddBuff(BuffID.WaterWalking, 2);
                player.AddBuff(BuffID.Gills, 2);

                player.moveSpeed += 0.75f;
                player.ClearBuff(194);
                player.meleeDamage += 0.1f;
                player.meleeSpeed += 0.1f;

                player.ClearBuff(20);
                player.AddBuff(BuffID.WeaponImbuePoison, 2);
                player.AddBuff(BuffID.Thorns, 2);
                player.AddBuff(BuffID.BabyHornet, 2);

                player.ClearBuff(47);
                player.ClearBuff(46);
                player.ClearBuff(44);
                player.AddBuff(BuffID.Warmth, 2);
            }
        }
    }
}