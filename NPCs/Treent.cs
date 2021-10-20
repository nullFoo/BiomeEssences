using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.NPCs
{
    public class Treent : ModNPC
    {
        int mode = 0;
        int[] modeTimers =
        {
            300,
            120,
            45,
        };
        int modesAmount = 2;
        int attackTimer = 0;

        bool arms = false;

        Vector2 moveTo;

        NPC treentArm1;
        NPC treentArm2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treent");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 68;
            npc.height = 142;

            npc.scale = 1.5f;

            npc.frame.Width = 68;
            npc.frame.Height = 142;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.lifeMax = 7000;
            npc.damage = 50;
            npc.defense = 50;

            npc.value = 15;

            npc.lavaImmune = false;

            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath15;

            npc.knockBackResist = 0;
        }
        

        public override void AI()
        {
            if(!arms)
            {
                int id = NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType("TreentArm"), 0, npc.whoAmI, 0, 1);
                treentArm1 = Main.npc[id];
                int id2 = NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType("TreentArm"), 0, npc.whoAmI, 0, -1);
                treentArm2 = Main.npc[id2];

                arms = true;
            }


            npc.TargetClosest(false);
            Player player = Main.player[npc.target];
            Vector2 target = player.Center;

            treentArm1.ai[1] = npc.target;
            treentArm2.ai[1] = npc.target;

            if (npc.life > npc.lifeMax)
                npc.life = npc.lifeMax;

            // despawning
            if(player.dead || !player.active)
            {
                npc.velocity.Y += 0.1f;
                if(npc.timeLeft > 20)
                {
                    npc.active = false;
                    treentArm1.active = false;
                    treentArm2.active = false;
                    return;
                }
            }
            
            attackTimer++;
            if (attackTimer > modeTimers[mode])
            {
                attackTimer = 0;
                mode++;
                if (mode > modeTimers.Length - 1)
                    mode = 0;
            }
            if (mode == 0)
            {
                npc.noGravity = false;
                npc.noTileCollide = false;
                npc.frame.Y = 0;
                npc.FaceTarget();
                Vector2 moveTo = player.Center;
                float speed = 0.1f;
                Vector2 move = moveTo - npc.Center;
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                move *= speed / magnitude;
                if(Math.Abs(npc.velocity.X) < 5f)
                    npc.velocity.X += move.X;

                if (Main.time % 60 == 0)
                {
                    if(!(treentArm1.active && treentArm2.active))
                    {
                        npc.defense = 20;
                        for (int i = 0; i < 4; i++)
                        {
                            Vector2 spawnLoc = new Vector2(npc.Center.X, (npc.Center.Y - (npc.frame.Height * 0.5f)) + (i * (npc.frame.Height * 0.5f)));
                            Vector2 perturbedSpeed = (moveTo - spawnLoc) * 0.08f;
                            Projectile.NewProjectile(spawnLoc.X + (perturbedSpeed.X * 2), spawnLoc.Y + (perturbedSpeed.Y * 2), perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("RazorLeaf"), 25, 2, Main.myPlayer);
                            Main.PlaySound(SoundID.NPCHit13, npc.Center);
                        }
                    }
                }
            }
            else if(mode == 1)
            {
                npc.noGravity = false;
                npc.noTileCollide = false;
                npc.frame.Y = 0;
                npc.FaceTarget();
                Vector2 moveTo = player.Center;
                float speed = 4;
                Vector2 move = moveTo - npc.Center;
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                move *= speed / magnitude;
                npc.velocity.X = move.X;
                if (attackTimer <= 1)
                {
                    npc.velocity.X = 0;
                    npc.velocity.Y = -15;
                }
                if (npc.velocity.Y > 0)
                {
                    npc.velocity.Y = 30;
                }
                if (!(treentArm1.active && treentArm2.active))
                {
                    if (Main.time % 20 == 0)
                    {
                        Vector2 spawnLoc = new Vector2(npc.Center.X, npc.Center.Y - (npc.frame.Height * 0.5f));
                        Vector2 perturbedSpeed = (moveTo - spawnLoc) * 0.06f;
                        Projectile.NewProjectile(spawnLoc.X + (perturbedSpeed.X * 2), spawnLoc.Y + (perturbedSpeed.Y * 2), perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("RazorLeaf"), 25, 2, Main.myPlayer);
                        Main.PlaySound(SoundID.NPCHit13, npc.Center);
                    }
                }
                else
                {
                    if (Main.time % 30 == 0)
                    {
                        Vector2 spawnLoc = new Vector2(npc.Center.X, npc.Center.Y - (npc.frame.Height * 0.5f));
                        Vector2 perturbedSpeed = (moveTo - spawnLoc) * 0.06f;
                        Projectile.NewProjectile(spawnLoc.X + (perturbedSpeed.X * 2), spawnLoc.Y + (perturbedSpeed.Y * 2), perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("RazorLeaf"), 25, 2, Main.myPlayer);
                        Main.PlaySound(SoundID.NPCHit13, npc.Center);
                    }
                }
            }

            if(Vector2.Distance(player.Center, npc.Center) > 1000)
            {
                npc.noGravity = true;
                npc.noTileCollide = true;
                Vector2 moveTo = player.Center;
                float speed = 20;
                Vector2 move = moveTo - npc.Center;
                float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                move *= speed / magnitude;
                npc.velocity = move;
                Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 0);
            }
            if(npc.Center.Y - player.Center.Y > 250)
            {
                npc.velocity.Y = -15;
            }
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrownWisp"), Main.rand.Next(3, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(10, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 100));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 100));

            treentArm1.life = 0;
            treentArm2.life = 0;
        }

    }
}