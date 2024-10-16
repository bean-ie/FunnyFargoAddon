using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace FunnyFargoAddon.Items
{
    internal class TerraAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.width = 56;
            Item.height = 52;
            Item.knockBack = 7f;
            Item.useAnimation = 5;
            Item.useTime = 5;
            Item.axe = 200 / 5;
            Item.tileBoost = 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Item.sellPrice(gold: 20);
            Item.DamageType = DamageClass.Melee;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltWaraxe);
            recipe.AddIngredient(ItemID.PalladiumWaraxe);
            recipe.AddIngredient(ItemID.MythrilWaraxe);
            recipe.AddIngredient(ItemID.OrichalcumWaraxe);
            recipe.AddIngredient(ItemID.AdamantiteWaraxe);
            recipe.AddIngredient(ItemID.TitaniumWaraxe);
            recipe.AddIngredient(ItemID.LunarHamaxeSolar);
            recipe.AddIngredient(ItemID.LunarHamaxeVortex);
            recipe.AddIngredient(ItemID.LunarHamaxeNebula);
            recipe.AddIngredient(ItemID.LunarHamaxeStardust);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
