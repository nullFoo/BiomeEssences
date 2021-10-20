using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceSnow : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Snow");
            Tooltip.SetDefault("You gain buffs in the snow\n" +
                "Immune to Chilled, Frostburn and Frozen");
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
            
            recipe.AddIngredient(mod.GetItem("EssenceLesserSnow"), 1);
            recipe.AddIngredient(mod.GetItem("WhiteWisp"), 1);
            recipe.AddIngredient(ItemID.FrostCore, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneSnow)
            {
                player.ClearBuff(47);
                player.ClearBuff(46);
                player.ClearBuff(44);
                player.AddBuff(BuffID.Warmth, 2);
            }
        }
    }
}