using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceCorruption : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the Corruption");
            Tooltip.SetDefault("Gain buffs in the Corruption\n" +
                "Your weapons imbue Cursed Flames, and you are immune to it\n" +
                "Occaisonally spawns tiny worm heads to attack your enemies");
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

            recipe.AddIngredient(mod.GetItem("EssenceLesserCorruption"), 1);
            recipe.AddIngredient(ItemID.CursedFlame, 25);
            recipe.AddIngredient(ItemID.SoulofNight, 3);
            recipe.AddIngredient(mod.GetItem("PurpleWisp"), 5);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();
            modPlayer.corruptionEssence = false;
            if (player.ZoneCorrupt)
            {
                player.AddBuff(BuffID.WeaponImbueCursedFlames, 2);
                player.ClearBuff(BuffID.CursedInferno);
                player.statDefense += 3;
                player.thrownVelocity += 1;

                modPlayer.corruptionEssence = true;
            }
        }
    }
}