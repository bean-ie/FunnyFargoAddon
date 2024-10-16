using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FunnyFargoAddon.Items
{
    internal class True_Wood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Wood");
            Tooltip.SetDefault("'It looks like it belongs to a very powerful creature...'");
        }

        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ModContent.ItemType<WoodOfWoods>(), 2)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "EternalEnergy"), 2)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
