using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace BiomeEssences.NPCs.BossMinions
{
    public class MiniCrimera : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Crimera");
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 54;
            
            npc.aiStyle = 5;

            npc.lifeMax = 10;
            npc.damage = 10;
            npc.defense = 0;

            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath1;

            npc.noGravity = true;
            npc.friendly = false;

            npc.frame.Width = 38;
            npc.frame.Height = 54;
        }

        public override void NPCLoot()
        {
            if (Main.rand.Next(0, 5) == 1)
                Item.NewItem(npc.getRect(), ItemID.Heart);
        }
    }
}