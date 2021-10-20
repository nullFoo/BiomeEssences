using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories.Lesser
{
	public class EssenceLesserCavern : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lesser Essence of the Caverns");
            Tooltip.SetDefault("Gain buffs in the cavern layer");
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

			recipe.AddIngredient(ItemID.StoneBlock, 100);

            recipe.AddIngredient(ItemID.IronOre, 1);
            recipe.AddIngredient(ItemID.LeadOre, 1);
            recipe.AddIngredient(ItemID.GoldOre, 1);
            recipe.AddIngredient(ItemID.SilverOre, 1);
            recipe.AddIngredient(ItemID.PlatinumOre, 1);
            recipe.AddIngredient(ItemID.TungstenOre, 1);
            recipe.AddIngredient(ItemID.TinOre, 1);
            recipe.AddIngredient(ItemID.CopperPickaxe, 1);

            recipe.AddIngredient(mod.GetItem("Terragem"), 5);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneRockLayerHeight)
            {
                player.statDefense += 5;
                player.AddBuff(BuffID.NightOwl, 2);
                player.pickSpeed -= 0.2f;
            }
        }
    }
}