using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FunnyFargoAddon.Items;

namespace FunnyFargoAddon.NPCs
{
    internal class AddonGlobalNPC : GlobalNPC
    {
        public static int boss = -1;
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            Player player = Main.player[Main.myPlayer];
            AddonPlayer modPlayer = player.GetModPlayer<AddonPlayer>();
            
            if (modPlayer.TrueWoodEnchant)
            {
                for (int i = 0; i < 40; i++)
                {
                    shop.item[i].shopCustomPrice = 0;
                }
            }
        }

        public override bool CheckDead(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            AddonPlayer modPlayer = player.GetModPlayer<AddonPlayer>();
            if (modPlayer.TrueWoodEnchant)
            {
                TrueWoodEnchant.TrueWoodCheckDead(modPlayer, npc);
            }
            return base.CheckDead(npc);
        }
        public override bool PreAI(NPC npc)
        {
            if (npc.boss) boss = npc.type;
            return true;
        }
    }
}
