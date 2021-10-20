using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceSky : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Sky");
            Tooltip.SetDefault("Gain buffs while in the Sky layer\n" +
                "You can change gravity and you fall slower");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserSky"), 1);
            recipe.AddIngredient(mod.GetItem("CyanWisp"), 1);
            recipe.AddIngredient(ItemID.SoulofFlight, 20);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneSkyHeight)
            {
                player.moveSpeed += 0.1f;
                player.AddBuff(BuffID.Gravitation, 2);
                player.AddBuff(BuffID.Featherfall, 2);
                player.AddBuff(BuffID.Shine, 2);
            }
        }
    }
}