using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;

namespace FunnyFargoAddon.Items
{
    internal class WoodOfWoods : ModItem
    {
        public override void SetDefaults()
        {
            Item.maxStack = 9999;
            Item.rare = ItemRarityID.Cyan;
            Item.value = 1000;
            Item.width = 24;
            Item.height = 22;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.Wood)
                .AddIngredient(ItemID.RichMahogany)
                .AddIngredient(ItemID.Ebonwood)
                .AddIngredient(ItemID.Shadewood)
                .AddIngredient(ItemID.Pearlwood)
                .AddIngredient(ItemID.BorealWood)
                .AddIngredient(ItemID.PalmWood)
                .AddIngredient(ItemID.SpookyWood)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
