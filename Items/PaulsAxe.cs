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
    internal class PaulsAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paul's Axe");
        }
        public override void SetDefaults()
        {
            Item.damage = 54;
            Item.width = 62;
            Item.height = 56;
            Item.knockBack = 6f;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.axe = 150 / 5;
            Item.tileBoost = 3;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Item.sellPrice(gold: 15);
            Item.DamageType = DamageClass.Melee;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.MeteorHamaxe)
                .AddIngredient(ItemID.LucyTheAxe)
                .AddIngredient(ItemID.TheAxe)
                .AddIngredient(ItemID.Picksaw)
                .AddIngredient(ItemID.SpectreHamaxe)
                .AddIngredient(ItemID.PickaxeAxe)
                .AddIngredient(ItemID.ChlorophyteGreataxe)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
