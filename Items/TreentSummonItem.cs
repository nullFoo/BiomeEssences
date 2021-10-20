using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.Items
{
    public class TreentSummonItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Acorn");
            Tooltip.SetDefault("Pulsuating with energy\n" +
                "When used in the Forest, summons Treent");
        }

        public override void SetDefaults()
        {
            item.value = 0;
            item.rare = 2;
            item.maxStack = 99;
            item.consumable = true;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Acorn, 6);
            recipe.AddIngredient(ItemID.Daybloom, 1);
            recipe.AddIngredient(ItemID.PalladiumBar, 5);
            recipe.AddIngredient(ItemID.Squirrel, 1);

            recipe.AddTile(TileID.DemonAltar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Acorn, 6);
            recipe.AddIngredient(ItemID.Daybloom, 1);
            recipe.AddIngredient(ItemID.CobaltBar, 5);
            recipe.AddIngredient(ItemID.Squirrel, 1);

            recipe.AddTile(TileID.DemonAltar);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)
        {
                return player.ZoneOverworldHeight && !player.ZoneCorrupt && !player.ZoneCrimson && !player.ZoneHoly && !player.ZoneJungle && !player.ZoneSnow && !player.ZoneDesert && !player.ZoneGlowshroom;
        }

        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, mod.NPCType("Treent"));
            Main.PlaySound(SoundID.Roar, (int)player.position.X, (int)player.position.Y, 0);
            return true;
        }
    }
}