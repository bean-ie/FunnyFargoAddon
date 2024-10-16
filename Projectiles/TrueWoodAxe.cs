using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace FunnyFargoAddon.Projectiles
{
    internal class TrueWoodAxe : ModProjectile
    {
        public override string Texture => "FunnyFargoAddon/Items/TrueLumberjaxe";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Lumber Jaxe Projectile");
        }

        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.timeLeft = 300;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 69696969;
            Projectile.friendly = true;
            Projectile.width = 128;
            Projectile.height = 128;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.CritChance = 100;
        }

        public float angle;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            AddonPlayer modPlayer = player.GetModPlayer<AddonPlayer>();

            if (player.ownedProjectileCounts[Projectile.type] > 1 | !modPlayer.TrueWoodEnchant)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.timeLeft = 2;
            }

            if (player == Main.LocalPlayer && modPlayer.TrueWoodEnchant)
            {
                float distanceToMouse = (Main.MouseWorld - player.Center).Length();
                float multiplier = /*modPlayer.TrueWoodSet ? 10f :*/ 5f;
                angle = Projectile.ai[0] * (MathF.PI / 180f) * multiplier;
                Projectile.Center = player.Center + new Vector2(distanceToMouse, 0f).RotatedBy(angle);
                Projectile.velocity = Vector2.Zero;
                Projectile.ai[0]++;
                if (Projectile.ai[0] > 360f) Projectile.ai[0] = 0;
                Projectile.rotation = angle + MathF.PI/4;
            }
        }
    }
}
