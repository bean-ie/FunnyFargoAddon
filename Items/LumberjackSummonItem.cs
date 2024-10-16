using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using FunnyFargoAddon.NPCs;
using FunnyFargoAddon;

namespace FunnyFargoAddon.Items
{
    internal class LumberjackSummonItem : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wooden Token");
            Tooltip.SetDefault("It seems too powerful for you to handle... For now\n'The sign of a true wood killer'");
        }

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.maxStack = 20;
            Item.value = 100000;
            Item.rare = ItemRarityID.Purple;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        /*public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<LumberjackBoss>());
        }*/

        public override bool? UseItem(Player player)
        {
            /*int type = ModContent.NPCType<LumberjackBoss>();
            if (player.whoAmI == Main.myPlayer && !NPC.AnyNPCs(type))   
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    NPC.SpawnOnPlayer(player.whoAmI, type);
                    NPC lumberBoss = AddonUtils.NPCExists(NPC.FindFirstNPC(type));
                    NPC lumberJack = AddonUtils.NPCExists(NPC.FindFirstNPC(ModContent.Find<ModNPC>("Fargowiltas", "LumberJack").Type));
                    if (lumberJack != null)
                    {
                        lumberBoss.position = lumberJack.position;
                        lumberJack.life = 0;
                        lumberJack.active = false;
                    }
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBoss, number: player.whoAmI, number2: type);
                }
            }*/
            player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " was too weak."), 222222, 1);
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "DeviatingEnergy"), 99)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "AbomEnergy"), 99)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "EternalEnergy"), 99)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "DevisCurse"))
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "AbomsCurse"))
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "MutantsCurse"))
                .AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "Squirrel"))
                .AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "WoodenToken"))
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
