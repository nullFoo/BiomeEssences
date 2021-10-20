using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BiomeEssences.NPCs
{
    [AutoloadBossHead]
    public class CrimsonHeart : ModNPC
    {

        int ai;
        int mode = 0;
        int[] modeTimers =
        {
            300,
            30,
            45,
            300,
            300,
        };
        int[] stillTimers =
         {
            120,
            30,
            120,
            120,
            120,
        };
        int modesAmount = 5;
        int attackTimer = 0;
        bool dashing = false;
        bool still = false;
        int stillTimer = 0;

        Vector2 moveTo;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Bleeding Heart");
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.width = 60;
            npc.height = 60;

            npc.scale = 2f;

            npc.boss = true;
            npc.aiStyle = -1;

            npc.lifeMax = 5000;
            npc.damage = 50;
            npc.defense = 20;

            npc.value = 15;

            npc.lavaImmune = true;
            npc.immortal = false;
            npc.dontTakeDamage = false;

            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath15;
        }

        public override void AI()
        {
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

            if(still)
            {
                SetDefaults();
                npc.defense = 50;
                if ((mode == 0 || mode > 1)&& stillTimer == 0)
                    npc.velocity = Vector2.Zero;
                npc.knockBackResist = 0;
                npc.noGravity = false;
                npc.noTileCollide = false;
                npc.frame.Y = 60;
                stillTimer++;
                if(stillTimer > stillTimers[mode])
                {
                    SetDefaults();
                    still = false;
                    stillTimer = 0;
                    mode++;
                    if (mode > modesAmount - 1)
                        mode = 0;
                }
            }
            else
            {
                npc.rotation = (float)Main.time / 60;
                attackTimer++;
                if (attackTimer > modeTimers[mode])
                {
                    attackTimer = 0;
                    still = true;
                }
                if (mode == 0)
                {
                    npc.knockBackResist = 0.5f;
                    npc.noGravity = false;
                    npc.noTileCollide = false;
                    npc.frame.Y = 0;
                    npc.FaceTarget();
                    Vector2 moveTo = player.Center;
                    float speed = 0.1f;
                    Vector2 move = moveTo - npc.Center;
                    float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                    move *= speed / magnitude;
                    if(Math.Abs(npc.velocity.X) < 1)
                        npc.velocity.X += move.X;

                    if (Main.time % 60 == 0)
                    {

                        Vector2 perturbedSpeed = (moveTo - npc.Center) * 0.03f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GoldenShowerHostile, 25, 1, player.whoAmI);
                        Main.PlaySound(SoundID.NPCHit13, npc.Center);
                    }
                }
                else if(mode == 1 || mode == 2)
                {
                    npc.damage = 50;
                    npc.knockBackResist = 0;
                    if (attackTimer == 0)
                        Main.PlaySound(SoundID.Roar, (int)npc.Center.X, (int)npc.Center.Y, 0);
                    npc.noGravity = true;
                    npc.noTileCollide = true;
                    npc.frame.Y = 0;
                    npc.FaceTarget();
                    Vector2 moveTo = player.Center;
                    float speed = Vector2.Distance(moveTo, npc.Center) * 0.1f; //15;
                    Vector2 move = moveTo - npc.Center;
                    float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                    move *= speed / magnitude;
                    if(attackTimer < 15)
                        npc.velocity = move;
                    Dust.NewDust(npc.Center, 32, 32, DustID.Ichor);
                }
                else if(mode == 3)
                {
                    npc.knockBackResist = 0;
                    npc.noGravity = true;
                    npc.noTileCollide = true;

                    npc.frame.Y = 0;

                    npc.FaceTarget();
                    Vector2 moveTo = player.Center + new Vector2(0, -250);
                    float speed = Vector2.Distance(npc.Center, moveTo) * 0.25f;
                    Vector2 move = moveTo - npc.Center;
                    float magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                    move *= speed / magnitude;
                    npc.velocity = move;

                    if(Main.time % 60 == 0)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Vector2 perturbedSpeed = new Vector2(1f, 1f).RotatedBy(i * 36);
                            Vector2 projLoc = npc.Center + (perturbedSpeed * 60);
                            Projectile.NewProjectile(projLoc.X, projLoc.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GoldenShowerHostile, 15, 1, player.whoAmI);
                        }
                        Vector2 down = new Vector2(0, 1);
                        Vector2 projLocDown = npc.Center + (down * 60);
                        Projectile.NewProjectile(projLocDown.X, projLocDown.Y, down.X, down.Y, ProjectileID.GoldenShowerHostile, 25, 1, player.whoAmI);
                        Main.PlaySound(SoundID.NPCHit13, npc.Center);
                    }
                }
                else if(mode == 4)
                {
                    npc.dontTakeDamage = true;
                    npc.knockBackResist = 0;
                    npc.noGravity = true;
                    npc.noTileCollide = true;

                    Vector2 rotation = new Vector2(1.5f, 1.5f).RotatedBy((Main.time * 0.01f));
                    Vector2 loc = player.Center + (rotation * 150);
                    npc.position = loc;

                    npc.frame.Y = 0;

                    if (Main.time % 60 == 0)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("MiniCrimera"));
                    }
                }
            }

            ai++;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RedWisp"), Main.rand.Next(3, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GreaterHealingPotion, Main.rand.Next(1, 10));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(10, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 100));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 100));
        }

    }
}