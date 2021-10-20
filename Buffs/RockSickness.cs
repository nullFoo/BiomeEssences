using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace BiomeEssences.Buffs
{
    public class RockSickness : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("RockSickness");
            Description.SetDefault("Unable to enter rock state");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
    }
}