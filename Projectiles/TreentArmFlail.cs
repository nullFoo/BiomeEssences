using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BiomeEssences.Projectiles
{
    public class TreentArmFlail : ModProjectile
    {

        private const string ChainTexturePath = "BiomeEssences/Projectiles/TreentArmFlailChain";
        int time = 0;
        bool destroy = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treent Arm"); // Set the projectile name to Example Flail Ball
        }

        public override void SetDefaults()
        {
            projectile.width = 64;
            projectile.height = 64;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.aiStyle = 1;
            projectile.tileCollide = true;
        }
        public override void AI()
        {
            base.AI();
            if (destroy)
                time++;
            if (time > 60)
                projectile.Kill();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            // ai[0] == 1 is used in AI to represent that the projectile has hit a tile since spawning
            projectile.ai[0] = 1f;
            // if we should play the sound..
            projectile.netUpdate = true;
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            //Main.tile[(int)projectile.position.X, (int)projectile.position.Y]
            // Play the sound
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);

            projectile.velocity = -projectile.oldVelocity * 0.5f;
            destroy = true;

            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var player = Main.player[projectile.owner];

            Vector2 mountedCenter = player.MountedCenter;
            Texture2D chainTexture = ModContent.GetTexture(ChainTexturePath);

            var drawPosition = projectile.Center;
            var remainingVectorToPlayer = mountedCenter - drawPosition;

            float rotation = remainingVectorToPlayer.ToRotation() - MathHelper.PiOver2;

            if (projectile.alpha == 0)
            {
                int direction = -1;

                if (projectile.Center.X < mountedCenter.X)
                    direction = 1;

                player.itemRotation = (float)Math.Atan2(remainingVectorToPlayer.Y * direction, remainingVectorToPlayer.X * direction);
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
                remainingVectorToPlayer = mountedCenter - drawPosition;

                // Finally, we draw the texture at the coordinates using the lighting information of the tile coordinates of the chain section
                Color color = Lighting.GetColor((int)drawPosition.X / 16, (int)(drawPosition.Y / 16f));
                spriteBatch.Draw(chainTexture, drawPosition - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);
            }

            return true;
        }
    }
}