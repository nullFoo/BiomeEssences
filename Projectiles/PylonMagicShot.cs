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
    public class PylonMagicShot : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowHostile);
            projectile.tileCollide = false;
            projectile.stepSpeed = 4;
            projectile.hostile = true;
            projectile.Name = "Pylon's Magic Shot";
            aiType = ProjectileID.CrystalDart;
        }

        public override void AI()
        {
            Dust.NewDust(projectile.Center, 16, 16, DustID.Flare_Blue);
            Main.tile[(int)projectile.position.X / 16, (int)projectile.position.Y / 16].inActive(true);
        }
    }    
}