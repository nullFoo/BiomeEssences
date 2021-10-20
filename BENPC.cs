using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace BiomeEssences
{

    public class BENPC : GlobalNPC
    {
        static int[] gems =
        {
            ItemID.Amethyst,
            ItemID.Sapphire,
            ItemID.Topaz,
            ItemID.Emerald,
            ItemID.Ruby,
            ItemID.Diamond,
        };

        public override void NPCLoot(NPC npc)
        {
            for (int i = 0; i < npc.lifeMax / 10; i++)
            {
                if(Main.rand.Next(1, 10) == 5)
                    Item.NewItem(npc.getRect(), gems[Main.rand.Next(0, gems.Length)]);
            }
        }
    }
}