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
    [AutoloadEquip(EquipType.Legs)]
    internal class True_Wood_Greaves : ModItem
    {
        public override void SetDefaults()
        {
            Item.defense = 130;
            Item.value = Item.sellPrice(platinum: 10);
            Item.rare = ItemRarityID.Purple;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += .65f;
            player.GetCritChance(DamageClass.Generic) += 33f;
            player.moveSpeed += .8f;
            player.ammoCost75 = true;
            player.manaCost -= .5f;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wood Greaves");
            Tooltip.SetDefault("65% increased damage and 33% increased critical strike chance \n80% increased movement and melee speed\n50% reduced mana usage and 25% chance not to consume ammo");
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodGreaves);
            recipe.AddIngredient(ItemID.RichMahoganyGreaves);
            recipe.AddIngredient(ItemID.EbonwoodGreaves);
            recipe.AddIngredient(ItemID.ShadewoodGreaves);
            recipe.AddIngredient(ItemID.PearlwoodGreaves);
            recipe.AddIngredient(ItemID.BorealWoodGreaves);
            recipe.AddIngredient(ItemID.PalmWoodGreaves);
            recipe.AddIngredient(ItemID.SpookyLeggings);
            recipe.AddIngredient(null, "True_Wood", 25);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));

            recipe.Register();
        }
    }
}
