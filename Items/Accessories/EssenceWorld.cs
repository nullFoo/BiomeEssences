using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceWorld : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of the World");
            Tooltip.SetDefault("All the layers of the earth\n" +
                "Gives the effects of the Essences of the Underworld, Caverns, Forest and Sky");
		}

		public override void SetDefaults() 
		{
			item.accessory = true;
			item.value = 25;
			item.rare = 8;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.GetItem("EssenceUnderworld"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceCavern"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceForest"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceSky"), 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();
            modPlayer.cavernEssence = false;
            if (
                (!player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneDesert && !player.ZoneGlowshroom)
                || player.ZoneSkyHeight
                || player.ZoneUnderworldHeight
                )
            {
                player.moveSpeed += 0.1f;
                player.AddBuff(BuffID.ObsidianSkin, 2);
                player.AddBuff(BuffID.WeaponImbueFire, 2);

                player.statDefense += 3;
                player.AddBuff(BuffID.NightOwl, 2);
                player.AddBuff(BuffID.WellFed, 2);

                player.moveSpeed += 0.1f;
                player.AddBuff(BuffID.Gravitation, 2);
                player.AddBuff(BuffID.Featherfall, 2);
                player.AddBuff(BuffID.Shine, 2);

                player.statDefense += 5;
                player.AddBuff(BuffID.NightOwl, 2);
                player.pickSpeed -= 0.2f;
                player.AddBuff(BuffID.Spelunker, 2);
                modPlayer.cavernEssence = true;
            }
        }
    }
}