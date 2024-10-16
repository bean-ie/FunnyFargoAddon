/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace FunnyFargoAddon.Projectiles
{
    internal class LumberbossAcorn : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Acorn");
        }
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.scale = 1;
            Projectile.timeLeft = 300;
        }
        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4 * 5;
            if (Projectile.ai[0] != -1)
            {
                if (Projectile.localAI[0] > 30 && Projectile.localAI[0] < 90)
                {
                    Vector2 directionToPlayer = Main.player[(int)Projectile.ai[0]].Center - Projectile.Center;
                    directionToPlayer.Normalize();
                    Projectile.velocity = directionToPlayer * (Main.player[(int)Projectile.ai[0]].velocity.Length() + 1);
                }
                Projectile.localAI[0]++;
            }
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            Projectile.Kill();
        }
    }
}*/
