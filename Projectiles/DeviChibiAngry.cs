/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using FargowiltasSouls.Projectiles.DeviBoss;
using FargowiltasSouls;

namespace FunnyFargoAddon.Projectiles
{
    public class DeviChibiAngry : ModProjectile
    {
        public override string Texture => "FargowiltasSouls/Projectiles/Pets/ChibiDevi";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chibi Devi");
            Main.projFrames[Projectile.type] = 6;
            Main.projPet[Projectile.type] = true;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 44;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 2000;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
        }
        Player player;
        float[] extraAI = { 0, 0, 0, 0 };
        int attack = 0;
        int talkTimer = 0;
        public override void AI()
        {
            player = Main.player[(int)Projectile.ai[0]];
            if (player == null || !player.active || player.dead)
                Projectile.Kill();

            if (++talkTimer > Main.rand.Next(40, 500))
            {
                talkTimer = 0;
                Talk();
            }

            if (attack == 0)
                Fireballs();
            else if (attack == 1)
            {
                //wait
                if (++Projectile.localAI[0] == 60 * 2)
                {
                    Projectile.localAI[0] = 0;
                    attack = 2;
                }
            }
            else if (attack == 2)
                Hammer();


            if (++Projectile.frameCounter > 6)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                    Projectile.frame = 0;
            }
        }
        private void Fireballs()
        {
            Projectile.position = player.position + Vector2.UnitY * -300 + Vector2.UnitX * (float)Math.Sin(++extraAI[0] / 10) * 200 * Projectile.ai[1];


            Projectile.spriteDirection = Projectile.Center.X < player.Center.X ? 1 : -1;
            if (Projectile.localAI[1] < 5)
            {
                if (++Projectile.localAI[0] == 60)
                {
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 blastPos = Projectile.Center + Main.rand.NextFloat(1, 2) * Projectile.Distance(player.Center) * Projectile.DirectionTo(player.Center);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Projectile.DirectionTo(player.Center) * 10f, ProjectileID.InfernoHostileBolt, Projectile.damage, 0.5f, Main.myPlayer, blastPos.X, blastPos.Y);
                    }
                    Projectile.localAI[0] = 0;
                    Projectile.localAI[1]++;
                }
            }
            else
            {
                Projectile.localAI[1] = 0;
                attack = 1;
                extraAI[0] = 0;
                extraAI[1] = 0;
                extraAI[2] = 0;
                extraAI[3] = 0;
            }

        }
        private void Hammer()
        {
            if (Projectile.localAI[0] == 0) //teleport behind you
            {
                Projectile.localAI[0] = 1;


                SoundEngine.PlaySound(SoundID.Item84, Projectile.Center);
                SoundEngine.PlaySound(SoundID.Roar, Projectile.Center);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Projectile.Center.X < player.Center.X ? -1f : 1f, -1f),
                        ModContent.ProjectileType<DeviChibiLove>(), Projectile.damage, 0f, Main.myPlayer, Projectile.whoAmI, 0.0001f * Math.Sign(player.Center.X - Projectile.Center.X));
                }
            }
            if (++extraAI[3] > 2)
            {
                extraAI[3] = 0;

                if (Main.netMode != NetmodeID.MultiplayerClient) //make moth dust trail
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Main.rand.NextVector2Unit() * 2f, ModContent.ProjectileType<DeviMothDust>(), Projectile.damage, 0f, Main.myPlayer);
            }
            if (extraAI[1] == 0)
            {
                int max = FargoSoulsWorld.MasochistModeReal ? 8 : 3;
                float spread = FargoSoulsWorld.MasochistModeReal ? 64 : 48;
                for (int i = 0; i < max; i++)
                {
                    Vector2 target = player.Center + player.velocity * 20f - Projectile.Center;
                    target += Main.rand.NextVector2Circular(spread, spread);

                    Vector2 speed = 2 * target / 90;
                    float acceleration = -speed.Length() / 90;

                    int damage = FargoSoulsUtil.ScaledProjectileDamage(Projectile.damage);

                    float rotation = FargoSoulsWorld.MasochistModeReal ? MathHelper.ToRadians(Main.rand.NextFloat(-10, 10)) : 0;
                }
            }
            if (++extraAI[1] > 45)
            {
                if (++extraAI[2] > 5)
                {
                    Projectile.Kill();
                }
                else
                {
                    extraAI[0]++;
                    extraAI[1] = 0;
                    Projectile.velocity = Projectile.DirectionTo(player.Center + player.velocity) * 20f;
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        float rotation = MathHelper.Pi * 1.5f * (extraAI[2] % 2 == 0 ? 1 : -1);
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Normalize(Projectile.velocity).RotatedBy(-rotation / 2),
                            ModContent.ProjectileType<DeviChibiLove>(), FargoSoulsUtil.ScaledProjectileDamage(Projectile.damage), 0f, Main.myPlayer, Projectile.whoAmI, rotation / 60 * 2);
                    }
                }
            }
        }
        private void Talk()
        {
            string[] phrases = {
                "Don't get cocky kid",
                "Murder! murder!",
                "Fun time! killing time!",
                "Fell the balls!",
                "Get mad!",
                "A deviantt doesnt fear Death!",
                "What a beautiful weather!",
                "You're no match for my axe!",
                "Remember Kids its fun to kill!",
                "Hit it like you mean it!",
                "And now, you die!",
                "The chibi comes from you!",
                "Pain for you",
                "Love can hurt too",
                "You are doomed!"
            };
            Rectangle displayPoint = new Rectangle(Projectile.Hitbox.Center.X, Projectile.Hitbox.Center.Y - Projectile.height / 4, 2, 2);
            CombatText.NewText(displayPoint, Color.HotPink, phrases[Main.rand.Next(0, phrases.Length)]);
            SoundEngine.PlaySound(new SoundStyle(Main.rand.NextBool() ? "SatanistReborn/Assets/Sounds/ChibiEvil2" : "SatanistReborn/Assets/Sounds/ChibiEvil1"), Projectile.Center);
        }
        public override void Kill(int timeLeft)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.UnitY * 7, ModContent.ProjectileType<DeviChasingHeart>(), Projectile.damage, 0f, Main.myPlayer, Projectile.ai[0]);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value;
            int num156 = Terraria.GameContent.TextureAssets.Projectile[Projectile.type].Value.Height / Main.projFrames[Projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * Projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            SpriteEffects spriteEffects = Projectile.spriteDirection < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Color color26 = new Color(255, 51, 153, 50);
            float speedRatio = Math.Min(Projectile.velocity.Length() / 16f / 2f, 1f);

            for (float i = 0; i < ProjectileID.Sets.TrailCacheLength[Projectile.type]; i += 0.2f)
            {
                Color color27 = color26 * 0.4f * speedRatio;
                float fade = (float)(ProjectileID.Sets.TrailCacheLength[Projectile.type] - i) / ProjectileID.Sets.TrailCacheLength[Projectile.type];
                color27 *= fade * fade;
                int max0 = (int)i - 1;//Math.Max((int)i - 1, 0);
                if (max0 < 0)
                    continue;
                float num165 = Projectile.oldRot[max0];
                Vector2 center = Vector2.Lerp(Projectile.oldPos[(int)i], Projectile.oldPos[max0], 1 - i % 1);
                center += Projectile.Size / 2;
                Main.EntitySpriteDraw(texture2D13, center - Main.screenPosition + new Vector2(0, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color27, num165, origin2, Projectile.scale, spriteEffects, 0);
            }

            color26 *= (float)Math.Sqrt(speedRatio);
            Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), color26, Projectile.rotation, origin2, Projectile.scale * 1.25f, spriteEffects, 0);

            Main.EntitySpriteDraw(texture2D13, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Projectile.GetAlpha(lightColor), Projectile.rotation, origin2, Projectile.scale, spriteEffects, 0);
            return false;
        }
        private void Movement(Vector2 playerPos, float speedModifier, float cap = 12f)
        {
            if (Math.Abs(Projectile.Center.X - playerPos.X) > 10)
            {
                if (Projectile.Center.X < playerPos.X)
                {
                    Projectile.velocity.X += speedModifier;
                    if (Projectile.velocity.X < 0)
                        Projectile.velocity.X += speedModifier * 2;
                }
                else
                {
                    Projectile.velocity.X -= speedModifier;
                    if (Projectile.velocity.X > 0)
                        Projectile.velocity.X -= speedModifier * 2;
                }
            }
            if (Projectile.Center.Y < playerPos.Y)
            {
                Projectile.velocity.Y += speedModifier;
                if (Projectile.velocity.Y < 0)
                    Projectile.velocity.Y += speedModifier * 2;
            }
            else
            {
                Projectile.velocity.Y -= speedModifier;
                if (Projectile.velocity.Y > 0)
                    Projectile.velocity.Y -= speedModifier * 2;
            }
            if (Math.Abs(Projectile.velocity.X) > cap)
                Projectile.velocity.X = cap * Math.Sign(Projectile.velocity.X);
            if (Math.Abs(Projectile.velocity.Y) > cap)
                Projectile.velocity.Y = cap * Math.Sign(Projectile.velocity.Y);
        }
    }
}*/
