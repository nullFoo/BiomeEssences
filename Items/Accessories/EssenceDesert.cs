using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceDesert : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Desert");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserDesert"), 1);
            recipe.AddIngredient(mod.GetItem("YellowWisp"), 1);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneDesert || player.ZoneUndergroundDesert)
            {
                player.moveSpeed += 0.75f;
                player.ClearBuff(194);
                player.meleeDamage += 0.1f;
                player.meleeSpeed += 0.1f;
            }
        }
    }
}