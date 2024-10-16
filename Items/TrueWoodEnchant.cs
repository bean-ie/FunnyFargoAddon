using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FunnyFargoAddon.Armor;
using FunnyFargoAddon.Projectiles;
using Microsoft.Xna.Framework;

namespace FunnyFargoAddon.Items
{
    internal class TrueWoodEnchant : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wood Enchantment");
            ItemID.Sets.ItemNoGravity[Type] = true;
            Tooltip.SetDefault("Bestiary entries complete instantly\nAll shop items are free\nSummons an axe to fight alongside you\n'The power of the forest, in the palm of my hand!'");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(gold: 15);
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AddonPlayer modPlayer = player.GetModPlayer<AddonPlayer>();
            modPlayer.TrueWoodEnchant = true;
            if (Main.myPlayer == player.whoAmI)
            {
                modPlayer.AddMinion(Item, ModContent.ProjectileType<TrueWoodAxe>(), 69696969, 5);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ModContent.ItemType<True_Wood_Helmet>())
                .AddIngredient(ModContent.ItemType<True_Wood_Breastplate>())
                .AddIngredient(ModContent.ItemType<True_Wood_Greaves>())
                .AddIngredient(ItemID.SharpeningStation)
                .AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "WoodenToken"))
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }

        public static void TrueWoodCheckDead(AddonPlayer modPlayer, NPC npc)
        {
            if (npc.ExcludedFromDeathTally())
                return;
            for (int i = 0; i < 50; i++)
            {
                    Main.BestiaryTracker.Kills.RegisterKill(npc);
            }
        }
    }
}
