using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace BiomeEssences.Projectiles
{
    public class RazorLeaf : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowHostile);
            projectile.stepSpeed = 4;
            projectile.hostile = true;
            projectile.Name = "Razor Leaf";
            aiType = ProjectileID.PoisonDart;
        }

        public override void AI()
        {
            base.AI();
            Dust.NewDust(projectile.Center, 16, 16, DustID.Plantera_Green);
        }

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

        }*/
    }    
}