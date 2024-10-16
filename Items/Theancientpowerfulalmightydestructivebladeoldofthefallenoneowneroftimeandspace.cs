using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace FunnyFargoAddon.Items
{
    public class Theancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The True Lumber Jaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Filled with the true power of The Lumberjack.\nNot inteded to be used by mortals.");
			
		}
        bool notboollol = true;
        public int TwistedStyle = 0;
        public override void SetDefaults()
		{
			Item.damage = 9999999;
			Item.DamageType = DamageClass.Melee;
			Item.width = 128;
			Item.height = 128;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 123456;
			Item.value = 99999999;
			Item.rare = ItemRarityID.Master;
            Item.UseSound = new SoundStyle("FunnyFargoAddon/Items/myinstants")
            {
                Volume = .8f,
                PitchVariance = 0.2f,
                MaxInstances = 5,
            };
            Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<TheancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspaceProj>();
			Item.shootSpeed = 12f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			
		}
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.LightBlue.ToVector3() * 0.70f * Main.essScale); // Makes this item glow when thrown out of inventory.
        }
        public override void HoldItem(Player player)
        {
            player.moveSpeed += 9.50f;
            player.GetDamage(DamageClass.Melee) += 0.80f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.80f;
            player.GetDamage(DamageClass.Ranged) += 0.70f;
            player.GetAttackSpeed(DamageClass.Ranged) += 0.70f;
            player.GetDamage(DamageClass.Magic) += 0.60f;
            player.GetAttackSpeed(DamageClass.Magic) += 0.60f;
            player.GetDamage(DamageClass.Summon) += 0.50f;
            player.GetAttackSpeed(DamageClass.Summon) += 0.50f;
            player.autoReuseGlove = true;
            player.meleeScaleGlove = true;
            player.jumpSpeedBoost += 2.4f;
            player.extraFall += 15;
            player.autoJump = true;
            player.accFlipper = true;
            player.spikedBoots = 2;
            player.blackBelt = true;
            player.kbGlove = true;
            player.lavaImmune = true;
            player.GetCritChance(DamageClass.Generic) = 100f;
            player.dashType = 2;
            player.GetArmorPenetration(DamageClass.Generic) += 1000f;
            player.GetKnockback(DamageClass.Generic) += 1000f;
            player.statDefense += 100;

        }
        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.Purple.ToVector3() * 0.7f);
            // Draw the periodic glow effect behind the item when dropped in the world (hence PreDrawInWorld)
            Texture2D texture = TextureAssets.Item[Item.type].Value;

            Rectangle frame;

            if (Main.itemAnimations[Item.type] != null)
            {
                // In case this item is animated, this picks the correct frame
                frame = Main.itemAnimations[Item.type].GetFrame(texture, Main.itemFrameCounter[whoAmI]);
            }
            else
            {
                frame = texture.Frame();
            }

            Vector2 frameOrigin = frame.Size() / 2f;
            Vector2 offset = new Vector2(Item.width / 2 - frameOrigin.X, Item.height - frame.Height);
            Vector2 drawPos = Item.position - Main.screenPosition + frameOrigin + offset;

            float time = Main.GlobalTimeWrappedHourly;
            float timer = Item.timeSinceItemSpawned / 240f + time * 0.04f;

            time %= 4f;
            time /= 2f;

            if (time >= 1f)
            {
                time = 2f - time;
            }

            time = time * 0.5f + 0.5f;

            for (float i = 0f; i < 1f; i += 0.15f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 8f).RotatedBy(radians) * time, frame, new Color(0, 255, 255, 40), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            for (float i = 0f; i < 1f; i += 0.20f)
            {
                float radians = (i + timer) * MathHelper.TwoPi;

                spriteBatch.Draw(texture, drawPos + new Vector2(0f, 6f).RotatedBy(radians) * time, frame, new Color(228, 87, 255, 55), rotation, frameOrigin, scale, SpriteEffects.None, 0);
            }

            return true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Item.noUseGraphic = true;
            if (TwistedStyle == 0)
            {

                if (player.velocity.Y > 5)
                {
                    if (player.direction == 0)
                        notboollol = true;
                    else
                        notboollol = false;
                }
                if (player.velocity.Y < -5)
                {
                    if (player.direction != 0)
                        notboollol = true;
                    else
                        notboollol = false;
                }

                int basic = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<TheancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspaceProj>(), damage, knockback, player.whoAmI);
                int basic2 = Projectile.NewProjectile(source, position, velocity, ModContent.ProjectileType<TheancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspaceProj>(), damage, knockback, player.whoAmI);
                if (notboollol == true)
                {
                    Main.projectile[basic].ai[1] = -1;
                    Main.projectile[basic2].ai[1] = -1;
                    notboollol = false;
                }

                else
                {
                    Main.projectile[basic].ai[1] = 1;
                    Main.projectile[basic2].ai[1] = 1;
                    notboollol = true;
                }
                Main.projectile[basic].rotation = Main.projectile[basic].DirectionTo(Main.MouseWorld).ToRotation();
            }
            return false;
        }

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod mod))
            {
                Recipe recipe = CreateRecipe();
                recipe.AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "LumberJaxe"));
                recipe.AddIngredient(null, "True_Wood", 50);
                recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "HentaiSpear"));
                recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "StyxGazer"));
                recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "SparklingLove"));
                recipe.AddIngredient(ModContent.ItemType<PhantasmalAxe>());
                recipe.AddIngredient(ModContent.ItemType<TrueWoodEnchant>());
                recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
                recipe.Register();
            }
        }

    }
    public class TheancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspaceProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The ancient powerful almighty destructive blade old of the fallen one owner of time and space");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;

        }

        public override void SetDefaults()
        {
            Projectile.damage = 999999999;
            Projectile.width = 1544;
            Projectile.height = 1552;
            //Projectile.aiStyle = 1;
            // AIType = ProjectileID.Bullet; // Act exactly like default Bullet
            Projectile.friendly = true;
            //projectile.magic = true;
            //projectile.extraUpdates = 100;
            Projectile.timeLeft = 20; // lowered from 300
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.CursedInferno, 6000);
            target.AddBuff(BuffID.OnFire, 6000);
            target.AddBuff(BuffID.OnFire3, 6000);
            if (Main.expertMode || Utils.NextBool(Main.rand))
            {
                for (int i3 = 0; i3 < BuffLoader.BuffCount; i3++)
                {
                    if (Main.debuff[i3])
                    {
                        target.AddBuff(i3, 600);
                    }
                }
            }
        }
        Vector2 dir = Vector2.Zero;
        Vector2 hlende = Vector2.Zero;

        public static float EaseIn(float t)
        {
            return t * t;
        }

        public static float Flip(float x)
        {
            return 1 - x;
        }

        public static float easeInOutQuad(float x)
        {
            return x < 0.5 ? 2 * x * x : 1 - (float)Math.Pow(-2 * x + 2, 2) / 2;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = ModContent.Request<Texture2D>("FunnyFargoAddon/Items/TheancientpowerfulalmightydestructivebladeoldofthefallenoneowneroftimeandspaceDraw").Value;

            // Redraw the projectile with the color not influenced by light
            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                if (Projectile.oldPos[i] == Vector2.Zero)
                    return false;
                for (float j = 0; j < 1; j += 0.0625f)
                {
                    Vector2 lerpedPos;
                    if (i > 0)
                        lerpedPos = Vector2.Lerp(Projectile.oldPos[i - 1], Projectile.oldPos[i], easeInOutQuad(j));
                    else
                        lerpedPos = Vector2.Lerp(Projectile.position, Projectile.oldPos[i], easeInOutQuad(j));
                    float lerpedAngle;
                    if (i > 0)
                        lerpedAngle = Utils.AngleLerp(Projectile.oldRot[i - 1], Projectile.oldRot[i], easeInOutQuad(j));
                    else
                        lerpedAngle = Utils.AngleLerp(Projectile.rotation, Projectile.oldRot[i], easeInOutQuad(j));
                    lerpedPos += Projectile.Size / 2;
                    lerpedPos -= Main.screenPosition;
                    Main.EntitySpriteDraw(texture, lerpedPos, null, Color.White * 0.5f * (1 - ((float)i / (float)Projectile.oldPos.Length)), lerpedAngle, new Vector2(texture.Width / 2, texture.Height / 2), 1, SpriteEffects.None, 0);
                }
            }
            return true;
        }
        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float rotationFactor = Projectile.rotation + (float)Math.PI / 4f; // The rotation of the Jousting Lance.
            float scaleFactor = 1552f; // How far back the hit-line will be from the tip of the Jousting Lance. You will need to modify this if you have a longer or shorter Jousting Lance. Vanilla uses 95f
            float widthMultiplier = 70f; // How thick the hit-line is. Increase or decrease this value if your Jousting Lance is thicker or thinner. Vanilla uses 23f
            float collisionPoint = 0f; // collisionPoint is needed for CheckAABBvLineCollision(), but it isn't used for our collision here. Keep it at 0f.

            // This Rectangle is the width and height of the Jousting Lance's hitbox which is used for the first step of collision.
            // You will need to modify the last two numbers if you have a bigger or smaller Jousting Lance.
            // Vanilla uses (0, 0, 300, 300) which that is quite large for the size of the Jousting Lance.
            // The size doesn't matter too much because this rectangle is only a basic check for the collision (the hit-line is much more important).
            Rectangle lanceHitboxBounds = new Rectangle(0, 0, 300, 300);

            // Set the position of the large rectangle.
            lanceHitboxBounds.X = (int)Projectile.position.X - lanceHitboxBounds.Width / 2;
            lanceHitboxBounds.Y = (int)Projectile.position.Y - lanceHitboxBounds.Height / 2;

            // This is the back of the hit-line with Projectile.Center being the tip of the Jousting Lance.
            Vector2 hitLineEnd = Projectile.Center + rotationFactor.ToRotationVector2() * -scaleFactor;
            if (/*lanceHitboxBounds.Intersects(targetHitbox)
                && */Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, hitLineEnd, widthMultiplier * Projectile.scale, ref collisionPoint))
            {
                return true;
            }
            return false;
        }

        public override void AI()
        {
            // All Projectiles have timers that help to delay certain events
            // Projectile.ai[0], Projectile.ai[1] � timers that are automatically synchronized on the client and server
            // Projectile.localAI[0], Projectile.localAI[0] � only on the client
            // In this example, a timer is used to control the fade in / out and despawn of the Projectile
            //Projectile.ai[0] += 1f;
            if (dir == Vector2.Zero)
            {
                dir = Main.MouseWorld;
                Projectile.rotation = (MathHelper.PiOver2 * Projectile.ai[1]) - MathHelper.PiOver4 + Projectile.DirectionTo(Main.MouseWorld).ToRotation();
            }
            //FadeInAndOut();
            Projectile.Center = Main.player[Projectile.owner].Center;
            Projectile.ai[0] += 1f;
            Projectile.rotation += (Projectile.ai[1] * MathHelper.ToRadians((20 - Projectile.ai[0])));
        }
    }
}