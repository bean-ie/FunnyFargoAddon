using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FunnyFargoAddon.Armor
{
    [AutoloadEquip(EquipType.Body)]
    internal class True_Wood_Breastplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 170;
            Item.value = Item.sellPrice(platinum: 10);
            Item.rare = ItemRarityID.Purple;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 1f;
            player.GetCritChance(DamageClass.Generic) += 33f;
            player.statLifeMax2 += 500;
            player.statManaMax2 += 500;
            player.endurance += .5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wood Breastplate");
            Tooltip.SetDefault("100% increased damage and 33% increased critical strike chance \nIncreases max life and mana by 500\nIncreases damage reduction by 50%");
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodBreastplate);
            recipe.AddIngredient(ItemID.RichMahoganyBreastplate);
            recipe.AddIngredient(ItemID.EbonwoodBreastplate);
            recipe.AddIngredient(ItemID.ShadewoodBreastplate);
            recipe.AddIngredient(ItemID.PearlwoodBreastplate);
            recipe.AddIngredient(ItemID.BorealWoodBreastplate);
            recipe.AddIngredient(ItemID.PalmWoodBreastplate);
            recipe.AddIngredient(ItemID.SpookyBreastplate);
            recipe.AddIngredient(null, "True_Wood", 30);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
