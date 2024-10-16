using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace FunnyFargoAddon.Projectiles
{
    internal class RicyezProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Daybreak);
            Projectile.width = 772;
            Projectile.height = 776;
            Projectile.timeLeft = 6000;
        }
    }
}
