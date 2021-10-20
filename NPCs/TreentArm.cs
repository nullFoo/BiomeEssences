using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BiomeEssences.NPCs
{
    public class TreentArm : ModNPC
    {
        private const string ChainTexturePath = "BiomeEssences/NPCs/TreentArmChain";

        bool goOut = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treent Arm");
            Main.npcFrameCount[npc.type] = 1;
        }

        public override void SetDefaults()
        {
            npc.width = 64;
            npc.height = 64;

            npc.frame.Width = 64;
            npc.frame.Height = 64;
            
            npc.aiStyle = -1;

            npc.lifeMax = 2500;
            npc.damage = 50;
            npc.defense = 20;

            npc.value = 15;

            npc.lavaImmune = false;

            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.HitSound = SoundID.NPCHit3;
            npc.DeathSound = SoundID.NPCDeath15;
        }

        Vector2 moveTo;
        float speed;
        Vector2 move;
        float magnitude;

        public override void AI()
        {
            NPC boss = Main.npc[(int)npc.ai[0]];
            Player player = Main.player[(int)npc.ai[1]];

            Vector2 homeCenter = boss.Center + new Vector2(50 * npc.ai[2], 0);

            if (Vector2.Distance(homeCenter, npc.Center) > 600)
            {
                goOut = false;
            }
            if(Vector2.Distance(homeCenter, npc.Center) <= 10) {
                moveTo = player.Center;
                speed = 10f;
                if (npc.life < npc.lifeMax * 0.5f)
                    speed = 20f;
                move = moveTo - npc.Center;
                magnitude = (float)Math.Sqrt(move.X * move.X + move.Y * move.Y);
                move *= speed / magnitude;

                goOut = true;
            }

            if(goOut)
            {
                if ((player.position.X > npc.position.X) == (npc.ai[2] == 1))
                {
                    npc.velocity = move;
                }
                else
                    goOut = false;
            }
            else
            {
                Vector2 moveTo2 = homeCenter;
                float speed2 = 15;
                if (Vector2.Distance(homeCenter, npc.Center) > 50)
                {
                    speed2 = 15f;
                    if (npc.life < npc.lifeMax * 0.5f)
                        speed2 = 30f;
                }
                else
                    speed2 = Vector2.Distance(homeCenter, npc.Center) * 0.1f;
                Vector2 move2 = moveTo2 - npc.Center;
                float magnitude2 = (float)Math.Sqrt(move2.X * move2.X + move2.Y * move2.Y);
                move2 *= speed2 / magnitude2;
                npc.velocity = move2;
            }

            if (npc.life < npc.lifeMax * 0.5f)
            {
                npc.onFire = true;
            }
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (npc.life > npc.lifeMax * 0.5f)
            {
                goOut = false;
            }
            base.OnHitByProjectile(projectile, damage, knockback, crit);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            goOut = false;

            if(npc.life < npc.lifeMax * 0.5f)
            {
                target.AddBuff(BuffID.OnFire, Main.rand.Next(30, 300));
            }
            base.OnHitPlayer(target, damage, crit);
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var boss = Main.npc[(int)npc.ai[0]];
            

            Vector2 bossCenter = boss.Center + new Vector2(0, -50);
            Texture2D chainTexture = ModContent.GetTexture(ChainTexturePath);

            var drawPosition = npc.Center;
            var remainingVectorToPlayer = bossCenter - drawPosition;

            float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

            if (npc.alpha == 0)
            {
                int direction = -1;

                if (npc.Center.X < bossCenter.X)
                    direction = 1;
            }

            // This while loop draws the chain texture from the projectile to the player, looping to draw the chain texture along the path
            while (true)
            {
                float length = remainingVectorToPlayer.Length();

                // Once the remaining length is small enough, we terminate the loop
                if (length < 25f || float.IsNaN(length))
                    break;

                // drawPosition is advanced along the vector back to the player by 12 pixels
                // 12 comes from the height of ExampleFlailProjectileChain.png and the spacing that we desired between links
                drawPosition += remainingVectorToPlayer * 12 / length;
                remainingVectorToPlayer = bossCenter - drawPosition;

                // Finally, we draw the texture at the coordinates using the lighting information of the tile coordinates of the chain section
                Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
                spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
            }

            return true;
        }

        public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.GoldCoin, Main.rand.Next(10, 15));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SilverCoin, Main.rand.Next(1, 100));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.CopperCoin, Main.rand.Next(1, 100));
        }

    }
}