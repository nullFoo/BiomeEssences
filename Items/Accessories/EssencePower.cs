using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssencePower : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Power");
            Tooltip.SetDefault("Sworn enemies brought together by their desire to spread\n" +
                "Gives the effects of the Essences of the Crimson, Corruption and Hallow");
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

            recipe.AddIngredient(mod.GetItem("EssenceCrimson"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceCorruption"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceHallow"), 1);

            recipe.AddIngredient(mod.GetItem("TerraxBar"), 5);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();
            modPlayer.corruptionEssence = false;
            modPlayer.crimsonEssence = false;
            if (player.ZoneCorrupt || player.ZoneCrimson || player.ZoneHoly)
            {
                player.crimsonRegen = true;
                player.meleeDamage += 0.05f;
                player.rangedDamage += 0.05f;
                player.minionDamage += 0.05f;
                modPlayer.crimsonEssence = true;

                player.AddBuff(BuffID.WeaponImbueCursedFlames, 2);
                player.ClearBuff(BuffID.CursedInferno);
                player.statDefense += 3;
                player.thrownVelocity += 1;
                modPlayer.corruptionEssence = true;

                player.magicDamage += 0.1f;
                player.manaCost -= 0.1f;
                player.moveSpeed += 0.05f;
                player.nightVision = true;
                player.AddBuff(BuffID.Shine, 2);
            }
        }
    }
}