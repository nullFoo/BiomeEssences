using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories.Lesser
{
	public class EssenceLesserDesert : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Essence of the Desert");
            Tooltip.SetDefault("Gain buffs in the desert\n" +
                "Immune to being slowed by wind");
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

            recipe.AddIngredient(ItemID.Cactus, 25);
            recipe.AddIngredient(ItemID.AntlionMandible, 5);
            recipe.AddIngredient(ItemID.DesertFossil, 10);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneDesert || player.ZoneUndergroundDesert)
            {
                player.moveSpeed += 0.5f;
                player.ClearBuff(194);
            }
        }
    }
}