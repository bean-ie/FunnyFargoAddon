using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Graphics;
using System.Net;
using FunnyFargoAddon.Buffs;

namespace FunnyFargoAddon.Items
{
    internal class EcchiSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Piercer");
            Tooltip.SetDefault("Summons 3 phantasmal spheres\nShoots both arrows and bullets around your cursor\nDoesn't consume ammo\nShooting 25 times throws the phantasmal spheres\n'The phantasmal gunbowspear of an undefeated foe'");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.knockBack = 7.5f;
            Item.rare = ItemRarityID.Purple;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.width = 58;
            Item.height = 58;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Ranged;
            Item.staff[Type] = true;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 25;
            Item.noMelee = true;

        }

        Item bulletAmmo, arrowAmmo;
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            bulletAmmo = null;
            arrowAmmo = null;
            for(int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].ammo == AmmoID.Bullet) bulletAmmo = player.inventory[i];
                else if (player.inventory[i].ammo == AmmoID.Arrow) arrowAmmo = player.inventory[i];
            }
            Vector2 spawnPosition = Main.MouseWorld + new Vector2(200, 0).RotatedByRandom(Math.PI * 2);
            Vector2 spawnVelocity = (Main.MouseWorld - spawnPosition);
            spawnVelocity.Normalize();
            spawnVelocity *= 15;
            if (bulletAmmo != null)
            {
                Projectile.NewProjectile(source, spawnPosition, spawnVelocity, bulletAmmo.shoot, damage + bulletAmmo.damage, knockback, player.whoAmI);
                SoundEngine.PlaySound(SoundID.Item11, spawnPosition);
            }
            spawnPosition = Main.MouseWorld + new Vector2(200, 0).RotatedByRandom(Math.PI * 2);
            spawnVelocity = (Main.MouseWorld - spawnPosition) * 15;
            spawnVelocity.Normalize();
            spawnVelocity *= 15;
            if (arrowAmmo != null)
            {
                Projectile.NewProjectile(source, spawnPosition, spawnVelocity, arrowAmmo.shoot, damage + arrowAmmo.damage, knockback, player.whoAmI);
                SoundEngine.PlaySound(SoundID.Item5, spawnPosition);
            }
            if (bulletAmmo != null || arrowAmmo != null) player.GetModPlayer<AddonPlayer>().EcchiSpearTimesShot++;
            return false;
        }

        public override void HoldItem(Player player)
        {
            player.GetModPlayer<AddonPlayer>().HoldingEcchiSpear = true;
            if (/*!player.HasBuff<LumberjackDebuff>()*/ true)
            {
            if ((player.ownedProjectileCounts[ModContent.ProjectileType<EcchiPhantasmalSphere>()] < 3))
            {
                for (int i = 0; i <= 240; i += 120)
                {
                    Projectile.NewProjectile(Item.GetSource_FromThis(), player.Center, Vector2.Zero, ModContent.ProjectileType<EcchiPhantasmalSphere>(), 200, 3, player.whoAmI, i);
                }
            }
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.FairyQueenRangedItem)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "Lightslinger"))
                .AddIngredient(ItemID.DayBreak)
                .AddIngredient(ItemID.LunarBar, 20)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }

    public class EcchiPhantasmalSphere : ModProjectile
    {   

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Phantasmal Sphere");
        }

        public override void SetDefaults()
        {
            Projectile.width = 58;
            Projectile.height = 58;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public float angle;
        public Vector2 rotationCenter, direction, origin;
        float multiplier = 5f;
        float distance = 150f;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            AddonPlayer modPlayer = player.GetModPlayer<AddonPlayer>();

            if (!modPlayer.HoldingEcchiSpear /*|| player.HasBuff<LumberjackDebuff>()*/) Projectile.Kill();

            if (player == Main.LocalPlayer && modPlayer.HoldingEcchiSpear)
            {
                if (Projectile.localAI[0] == 0)
                {
                    rotationCenter = player.Center;
                    Projectile.timeLeft = 2;

                    if (modPlayer.EcchiSpearTimesShot == 25)
                    {
                        Projectile.localAI[0] = 1;
                        origin = player.Center;
                        direction = Main.MouseWorld - origin;
                        direction.Normalize();
                        Projectile.velocity = direction * 20;
                        Projectile.damage = (int)((5000f) * player.GetDamage(DamageClass.Ranged).Multiplicative);
                        Projectile.timeLeft = 120;
                        multiplier = 20f;
                        SoundEngine.PlaySound(SoundID.Zombie100);
                    }
                } else if (Projectile.localAI[0] > 0)
                {
                    rotationCenter = origin + direction * Projectile.localAI[0];
                    Projectile.localAI[0] += 20;
                    distance *= 0.98f;
                }

                angle = Projectile.ai[0] * (MathF.PI / 180f) * multiplier;
                Projectile.Center = rotationCenter + new Vector2(distance, 0f).RotatedBy(angle);
                Projectile.velocity = Vector2.Zero;
                Projectile.rotation = angle + MathF.PI / 4;
                Projectile.ai[0]++;
                if (Projectile.ai[0] > 360f) Projectile.ai[0] = 0;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
        public override void Kill(int timeLeft)
        {
            Main.player[Projectile.owner].GetModPlayer<AddonPlayer>().EcchiSpearTimesShot = 0;
            base.Kill(timeLeft);
        }
        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.MaxMana);
            base.OnSpawn(source);
        }
    }

}
