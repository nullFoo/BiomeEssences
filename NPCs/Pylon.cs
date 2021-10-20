using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.NPCs
{
    public class Pylon : ModNPC
    {
        Vector2 moveTo;

        string[] mobIDS =
        {
            "MiniCrimera",
            "GemBat",
        };

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pylon");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 44;

            npc.scale = 1.5f;

            npc.frame.Width = 28;
            npc.frame.Height = 44;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.lifeMax = 2000;
            npc.damage = 20;
            npc.defense = 0;

            npc.value = 15;

            npc.lavaImmune = true;

            npc.noGravity = true;

            npc.HitSound = SoundID.NPCHit5;
            npc.DeathSound = SoundID.NPCDeath7;

            npc.knockBackResist = 0;

            npc.ai[0] = 0;
        }
        

        public override void AI()
        {
            npc.TargetClosest();
            Lighting.AddLight(npc.Center, 0.68627451f, 0.588235294f, 0.803921569f);

            if (Main.time % 5 == 0)
            {
                npc.frame.Y += npc.frame.Height;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * npc.frame.Height)
                    npc.frame.Y = 0;
            }


            npc.TargetClosest(false);
            Player player = Main.player[npc.target];
            Vector2 target = player.Center;

            if (npc.life > npc.lifeMax)
                npc.life = npc.lifeMax;

            // despawning
            if(player.dead || !player.active)
            {
                npc.velocity.Y += 0.1f;
                if(npc.timeLeft > 20)
                {
                    npc.active = false;
                    return;
                }
            }

            if(Main.time % 60 == 0)
            {
                if(Main.rand.Next(0,2) == 1)
                {
                    if (npc.ai[0] < 25)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType(mobIDS[Main.rand.Next(0, mobIDS.Length)]), 0, npc.whoAmI);
                        npc.ai[0]++;
                    }
                }
                else
                {
                    moveTo = player.Center;
                    Vector2 spawnLoc = new Vector2(npc.Center.X, npc.Center.Y - (npc.frame.Height * 0.5f));
                    Vector2 perturbedSpeed = (moveTo - spawnLoc) * 0.06f;
                    Projectile.NewProjectile(spawnLoc.X + (perturbedSpeed.X * 2), spawnLoc.Y + (perturbedSpeed.Y * 2), perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("PylonMagicShot"), 10, 2, Main.myPlayer);
                    Main.PlaySound(SoundID.Item15, npc.Center);
                }

                if(Main.rand.Next(0, 3) == 1)
                {
                    npc.position = player.Center + new Vector2(Main.rand.Next(-250, 250), Main.rand.Next(-250, 250));
                    //TODO: attack
                }
            }

            if(Vector2.Distance(player.Center, npc.Center) > 1000)
            {
                
            }
        }

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {
            return false;
        }
        public override bool? CanBeHitByItem(Player player, Item item)
        {
            return false;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            base.HitEffect(hitDirection, 0);
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrownWisp"), Main.rand.Next(3, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(10, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 100));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 100));
        }

    }
}