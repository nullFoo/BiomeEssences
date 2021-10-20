using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceJungle : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Jungle");
            Tooltip.SetDefault("Gain buffs in the Jungle\n" +
                "Your weapons imbue poison\n" +
                "Attackers also take damage\n" +
                "You have a baby hornet following you");
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


            recipe.AddIngredient(mod.GetItem("EssenceLesserJungle"), 1);
            recipe.AddIngredient(mod.GetItem("GreenWisp"), 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddIngredient(ItemID.TurtleShell, 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if(player.ZoneJungle)
            {
                player.ClearBuff(20);
                player.AddBuff(BuffID.WeaponImbuePoison, 2);
                player.AddBuff(BuffID.Thorns, 2);
                player.AddBuff(BuffID.BabyHornet, 2);
            }
        }
    }
}