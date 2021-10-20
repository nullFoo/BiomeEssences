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
    public class GemBat : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Bat");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 38;
            npc.height = 18;
            
            npc.aiStyle = 14;

            npc.lifeMax = 40;
            npc.damage = 10;
            npc.defense = 0;

            npc.HitSound = SoundID.NPCHit29;
            npc.DeathSound = SoundID.NPCDeath4;

            npc.noGravity = true;
            npc.friendly = false;

            npc.frame.Height = 38;
            npc.frame.Width = 18;
        }

        public override void AI()
        {
            if(Main.time % 10 == 0)
            {
                npc.frame.Y += npc.frame.Height;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * npc.frame.Height)
                    npc.frame.Y = 0;
            }
            base.AI();
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage = 0;
            base.ModifyHitByProjectile(projectile, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public override void NPCLoot()
        {
            NPC boss = Main.npc[(int)npc.ai[0]];
            boss.ai[0] -= 1;
            boss.life -= npc.lifeMax;
        }
    }
}