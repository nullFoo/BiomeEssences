using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceCrimson : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Crimson");
            Tooltip.SetDefault("Gain buffs in the Crimson\nChance to spray ichor when damaged");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserCrimson"), 1);
            recipe.AddIngredient(ItemID.Ichor, 25);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(mod.GetItem("RedWisp"), 5);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();
            modPlayer.crimsonEssence = false;
            if (player.ZoneCrimson)
            {
                player.crimsonRegen = true;
                player.meleeDamage += 0.05f;
                player.rangedDamage += 0.05f;
                player.minionDamage += 0.05f;
                modPlayer.crimsonEssence = true;
            }
        }
    }
}