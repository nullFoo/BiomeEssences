using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceUnderworld : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Underworld");
            Tooltip.SetDefault("Gain buffs in the Underworld or in lava\n" +
                "Can swim in lava\n" +
                "Immune to lava and fire damage\n" +
                "You weapons set enemies on fire");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserUnderworld"), 1);
            recipe.AddIngredient(mod.GetItem("OrangeWisp"), 1);
            recipe.AddIngredient(ItemID.FireFeather, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneUnderworldHeight)
            {
                player.moveSpeed += 0.1f;
                player.meleeDamage += 0.1f;
                player.AddBuff(BuffID.ObsidianSkin, 2);
                player.AddBuff(BuffID.WeaponImbueFire, 2);
            }
            if(player.adjLava)
            {
                player.AddBuff(BuffID.Flipper, 2);
            }
        }
    }
}