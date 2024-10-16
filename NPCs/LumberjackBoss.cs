/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FunnyFargoAddon.Buffs;
using FunnyFargoAddon.Projectiles;
using Terraria.Audio;

namespace FunnyFargoAddon.NPCs
{
    [AutoloadBossHead]
    internal class LumberjackBoss : ModNPC
    {

        Player player => Main.player[NPC.target];
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Lumberjack");
            Main.npcFrameCount[NPC.type] = 4;
            NPCID.Sets.NoMultiplayerSmoothingByType[NPC.type] = true;
            NPCID.Sets.MPAllowedEnemies[Type] = true;

            NPCID.Sets.BossBestiaryPriority.Add(NPC.type);
            NPCID.Sets.DebuffImmunitySets.Add(NPC.type, new Terraria.DataStructures.NPCDebuffImmunityData
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Confused,
                    BuffID.Chilled,
                    BuffID.OnFire,
                    BuffID.Suffocation,
                }
            });
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement("God")
            });
        }

        public override void SetDefaults()
        {
            NPC.width = 74;
            NPC.height = 46;
            NPC.damage = 300;
            NPC.defense = 0;
            NPC.lifeMax = 2147000000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.npcSlots = 1f;
            NPC.knockBackResist = 0;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.aiStyle = -1;
            NPC.netAlways = true;
            NPC.timeLeft = NPC.activeTime * 30;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            NPC.lifeMax = 2147000000;
        }
        public override bool? CanHitNPC(NPC target)
        {
            if (target.type == ModContent.Find<ModNPC>("Fargowiltas", "Squirrel").Type) return false;
            return base.CanHitNPC(target);
        }
        Vector2 offset = new Vector2(300, 0);
        int offsetAngle = 0;
        public override void AI()
        {
            if (!AliveCheck(player)) return;
            NPC.direction = NPC.spriteDirection = NPC.Center.X < player.Center.X ? 1 : -1;
            player.AddBuff(ModContent.BuffType<LumberjackDebuff>(), 2);

            //offsetAngle += 2;
            //if (offsetAngle >= 360) offsetAngle = 0;
            Vector2 directionToPlayer = player.Center - NPC.Center;
            directionToPlayer.Normalize();
            Vector2 target = player.Center + directionToPlayer * -350;
            Vector2 directionToTarget = target - NPC.Center;
            NPC.velocity = directionToTarget * (Vector2.Distance(NPC.Center, target) > 5 ? 0.08f : 0.04f);
            int p;
            if (NPC.ai[1] >= 10)
            {
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, directionToPlayer * 20, ModContent.ProjectileType<LumberbossAcorn>(), 200, 5, player.whoAmI, -1);
                NPC.ai[1] = 0;
                SoundEngine.PlaySound(SoundID.Item1, NPC.Center);
            }
            if (NPC.ai[2] >= 60)
            {
                for (int i = -1; i < 2; i += 2)
                {
                    p = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, (directionToPlayer * 17).RotatedBy(MathHelper.ToRadians(40 * i)), ModContent.ProjectileType<LumberbossAcorn>(), 200, 5, player.whoAmI, player.whoAmI);
                    if (p != Main.maxProjectiles) Main.projectile[p].scale = 2;
                }
                NPC.ai[2] = 0;
                SoundEngine.PlaySound(SoundID.Item1, NPC.Center);
            }
            NPC.ai[1]++;
            NPC.ai[2]++;
            //directionToPlayer.Normalize();
        }

        public override void FindFrame(int frameHeight)
        {
            if (++NPC.frameCounter > 4)
            {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameHeight;
                if (NPC.frame.Y >= Main.npcFrameCount[NPC.type] * frameHeight)
                    NPC.frame.Y = 0;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D texture2D13 = Terraria.GameContent.TextureAssets.Npc[NPC.type].Value;
            Vector2 position = NPC.Center - screenPos + new Vector2(0f, NPC.gfxOffY);
            Rectangle rectangle = NPC.frame;
            Vector2 origin2 = rectangle.Size() / 2f;

            SpriteEffects effects = NPC.spriteDirection < 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture2D13, position, new Rectangle?(rectangle), NPC.GetAlpha(drawColor), NPC.rotation, origin2, NPC.scale, effects, 0);

            return false;
        }
        bool AliveCheck(Player p, bool forceDespawn = false)
        {
            if (((!p.active || p.dead || Vector2.Distance(NPC.Center, p.Center) > 5000f)))
            {
                NPC.TargetClosest();
                p = Main.player[NPC.target];
                if (!p.active || p.dead || Vector2.Distance(NPC.Center, p.Center) > 5000f)
                {
                    if (NPC.timeLeft > 30)
                        NPC.timeLeft = 30;
                    NPC.velocity.Y -= 1f;
                    if (NPC.timeLeft == 1)
                    {
                        if (NPC.position.Y < 0)
                            NPC.position.Y = 0;
                        if (Main.netMode != NetmodeID.MultiplayerClient && ModContent.TryFind("Fargowiltas", "LumberJack", out ModNPC modNPC) && !NPC.AnyNPCs(modNPC.Type))
                        {
                            int n = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, modNPC.Type);
                            if (n != Main.maxNPCs)
                            {
                                Main.npc[n].homeless = true;
                                if (Main.netMode == NetmodeID.Server)
                                    NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, n);
                            }
                        }
                    }
                    return false;
                }
            }

            if (NPC.timeLeft < 3600)
                NPC.timeLeft = 3600;

            return true;
        }
    }
}*/
