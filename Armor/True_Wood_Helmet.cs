using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace FunnyFargoAddon.Armor
{
    [AutoloadEquip(EquipType.Head)]
    internal class True_Wood_Helmet : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 140;
            Item.value = Item.sellPrice(platinum: 10);
            Item.rare = ItemRarityID.Purple;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += .7f;
            player.GetCritChance(DamageClass.Generic) += 33f;
            player.lifeRegen += 20;
            player.lifeRegenCount += 20;
            player.lifeRegenTime += 20;
            player.maxMinions += 10;
            player.maxTurrets += 10;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wood Helmet");
            Tooltip.SetDefault("70% increased damage and 33% increased critical strike chance \nInsanely increased life regen\nIncreases max number of minions and sentries by 15");
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<True_Wood_Breastplate>() && legs.type == ModContent.ItemType<True_Wood_Greaves>();
        }

        Item currentAxe;
        int prevAxe, prevUseTime, prevUseAnimation;
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "\n3x damage \nInsanely increased axe power\n'Kore ga... Lumberjack... Da.'";
            player.GetDamage(DamageClass.Generic) *= 3f;
            if (player.HeldItem != currentAxe && currentAxe != null)
            {
                currentAxe.axe = prevAxe;
                currentAxe.useTime = prevUseTime;
                currentAxe.useAnimation = prevUseAnimation;
            }
            if (player.HeldItem.axe > 0)
            {
                currentAxe = player.HeldItem;
                prevAxe = currentAxe.axe;
                prevUseTime = currentAxe.useTime;
                prevUseAnimation = currentAxe.useAnimation;
                currentAxe.axe = 1000;
                currentAxe.useTime = 1;
                currentAxe.useAnimation = 1;
                
            }
            player.GetModPlayer<AddonPlayer>().TrueWoodSet = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodHelmet);
            recipe.AddIngredient(ItemID.RichMahoganyHelmet);
            recipe.AddIngredient(ItemID.EbonwoodHelmet);
            recipe.AddIngredient(ItemID.ShadewoodHelmet);
            recipe.AddIngredient(ItemID.PearlwoodHelmet);
            recipe.AddIngredient(ItemID.BorealWoodHelmet);
            recipe.AddIngredient(ItemID.PalmWoodHelmet);
            recipe.AddIngredient(ItemID.SpookyHelmet);
            recipe.AddIngredient(null, "True_Wood", 20);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
