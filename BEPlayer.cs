using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace BiomeEssences
{
    public class BEPlayer : ModPlayer
    {
        public bool cavernEssence;
        public bool crimsonEssence;
        public bool corruptionEssence;

        Random r = new Random();

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (BiomeEssences.EssenceEffectKey.JustPressed)
            {
                if(cavernEssence)
                {
                    Player p = Main.LocalPlayer;
                    if(!p.HasBuff(mod.BuffType("RockSickness")))
                    {
                        p.AddBuff(mod.BuffType("Rock"), 120);
                        p.AddBuff(mod.BuffType("RockSickness"), 420);
                    }
                }
            }
        }
        public override void PreUpdate()
        {
        }
        public override void PostUpdate()
        {
            base.PostUpdate();
            if(corruptionEssence && Main.time % 300 == 0)
            {
                Player p = Main.LocalPlayer;
                for (int i = 0; i < r.Next(0,4); i++)
                {
                    Vector2 perturbedSpeed = new Vector2(1.5f, 1.5f).RotatedByRandom(360);
                    Projectile.NewProjectile(p.position.X, p.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.TinyEater, 25, 1, player.whoAmI);
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit,
            ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (Main.LocalPlayer.HasBuff(mod.BuffType("Rock")))
            {
                damage = 0;
                customDamage = true;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if(crimsonEssence && r.Next(0, 5) == 1)
            {
                Player p = Main.LocalPlayer;
                for (int i = 0; i < 20; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(1.5f, 1.5f).RotatedBy(i * 18);
                    Projectile.NewProjectile(p.position.X, p.position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.GoldenShowerFriendly, 25, 1, player.whoAmI);
                }
                Main.PlaySound(SoundID.NPCHit13, p.position);
            }
        }
    }    
}