using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeEssences.Buffs
{
    public class Rock : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rock");
            Description.SetDefault("Grants invincibility and freezes you in place");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed = 0;
            player.velocity = Vector2.Zero;
            player.AddBuff(BuffID.Stoned, 2);
        }
    }
}