using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using FunnyFargoAddon.Items;
using FunnyFargoAddon.Buffs;
using System.Runtime;
using FunnyFargoAddon.Projectiles;
using FunnyFargoAddon.NPCs;

namespace FunnyFargoAddon
{
    internal class AddonPlayer : ModPlayer
    {
        public bool TrueWoodEnchant;
        public bool TrueWoodSet;
        public bool HoldingEcchiSpear;
        public int EcchiSpearTimesShot;
        public bool lumberjackDebuffActive;
        int deviDamage;

        public void AddMinion(Item item, int proj, int damage, float knockback, int maxMinions = 1)
        {
            if (Player.whoAmI != Main.myPlayer) return;
            if (Player.ownedProjectileCounts[proj] < maxMinions && Player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(Player.GetSource_Accessory(item), Player.Center, -Vector2.UnitY, proj, damage, knockback, Main.myPlayer);
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            base.ModifyHitNPCWithProj(proj, target, ref damage, ref knockback, ref crit, ref hitDirection);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (target.HasBuff<SparklingAppreciationDebuff>() && proj.minion)
            {
                deviDamage += damage;
            }
        }

        public override void PostUpdate()
        {
            if (deviDamage > 500)
            {
                Projectile.NewProjectile(Player.GetSource_FromThis(), Player.Center, -Vector2.UnitY, ProjectileID.BabySkeletronHead, 5, 0, Main.myPlayer);
                deviDamage = 0;
            }
            
            if(EcchiSpearTimesShot > 25)
            {
                EcchiSpearTimesShot = 0;
            }
        }

        public override void PreUpdate()
        {
            TrueWoodEnchant = false;
            TrueWoodSet = false;
            HoldingEcchiSpear = false;
        }

        public override bool CanUseItem(Item item)
        {
            //if (item.type == ModContent.Find<ModItem>("FargowiltasSouls", "HentaiSpear").Type && Main.player[Main.myPlayer].HasBuff(ModContent.BuffType<LumberjackDebuff>())) return false;
            return true;
        }
        public override void PostUpdateEquips()
        {
            /*if (Player.HasBuff<LumberjackDebuff>())
            {
                Player.statDefense *= 0;
                Player.lifeRegen *= 0;
                Player.endurance *= 0;
            }*/
        }
        public override void UpdateDead()
        {
            bool bossInWorld = false;

            for (int i = 0; i < Main.maxNPCs; ++i)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    bossInWorld = true;
                    break;
                }
            }

            if (bossInWorld && Player.respawnTimer < 10) Player.respawnTimer = 10;
        }
    }
}
