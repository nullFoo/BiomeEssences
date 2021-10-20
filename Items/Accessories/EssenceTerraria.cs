using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items.Accessories
{
	public class EssenceTerraria : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of Terraria");
            Tooltip.SetDefault("Pure energy of everything.\n" +
                "Gives the effects of all the essences no matter what biome you are in");
		}

		public override void SetDefaults() 
		{
			item.accessory = true;
			item.value = 100;
			item.rare = -12;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(mod.GetItem("EssenceWorld"), 1);
            recipe.AddIngredient(mod.GetItem("EssencePower"), 1);
            recipe.AddIngredient(mod.GetItem("EssenceMultitude"), 1);

            recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            BEPlayer modPlayer = player.GetModPlayer<BEPlayer>();
            modPlayer.cavernEssence = false;
            modPlayer.corruptionEssence = false;
            modPlayer.crimsonEssence = false;

            //World
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

            //Power
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

            //Multitude
            player.AddBuff(BuffID.Flipper, 2);
            player.AddBuff(BuffID.WaterWalking, 2);
            player.AddBuff(BuffID.Gills, 2);

            player.moveSpeed += 0.75f;
            player.ClearBuff(194);
            player.meleeDamage += 0.1f;
            player.meleeSpeed += 0.1f;

            player.ClearBuff(20);
            player.AddBuff(BuffID.WeaponImbuePoison, 2);
            player.AddBuff(BuffID.Thorns, 2);
            player.AddBuff(BuffID.BabyHornet, 2);

            player.ClearBuff(47);
            player.ClearBuff(46);
            player.ClearBuff(44);
            player.AddBuff(BuffID.Warmth, 2);
        }
    }
}