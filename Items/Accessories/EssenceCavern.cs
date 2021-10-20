using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceCavern : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Caverns");
            Tooltip.SetDefault("Gain buffs in the cavern layer\n" +
                "Be able to see all ores on screen\n" +
                "Press the Essence hotkey to temporarily turn to stone");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserCavern"), 1);

            recipe.AddIngredient(ItemID.SoulofSight, 15);
            recipe.AddIngredient(ItemID.Actuator, 15);
            
            recipe.AddIngredient(mod.GetItem("GreyWisp"), 5);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();

            modPlayer.cavernEssence = false;
            if (player.ZoneRockLayerHeight)
            {
                player.statDefense += 5;
                player.AddBuff(BuffID.NightOwl, 2);
                player.pickSpeed -= 0.2f;
                player.AddBuff(BuffID.Spelunker, 2);

                modPlayer.cavernEssence = true;
            }
        }
    }
}