using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceOcean : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Ocean");
            Tooltip.SetDefault("Gain buffs at the beach and while in water\n" +
                "Can swim and breathe in water");
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


            recipe.AddIngredient(mod.GetItem("EssenceLesserOcean"), 1);
            recipe.AddIngredient(mod.GetItem("BlueWisp"), 1);
            recipe.AddIngredient(ItemID.Trout, 1);
            recipe.AddIngredient(ItemID.SharkFin, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneBeach || player.adjWater)
            {
                player.AddBuff(BuffID.Flipper, 2);
                player.AddBuff(BuffID.WaterWalking, 2);
                player.AddBuff(BuffID.Gills, 2);
                player.AddBuff(BuffID.Regeneration, 2);
                player.AddBuff(BuffID.ManaRegeneration, 2);
            }
        }
    }
}