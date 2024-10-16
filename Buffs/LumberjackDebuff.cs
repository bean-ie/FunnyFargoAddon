/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace FunnyFargoAddon.Buffs
{
    internal class LumberjackDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            DisplayName.SetDefault("Lumberjack's Condition");
            Description.SetDefault("Armor and damage resistance reduced to 0");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AddonPlayer>().lumberjackDebuffActive = true;
        }
    }
}
*/