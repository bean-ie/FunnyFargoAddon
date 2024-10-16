/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FunnyFargoAddon.Items
{
    internal class TrueLumberjaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Lumber Jaxe");
        }
        public override void SetDefaults()
        {
            Item.damage = 16092016;
            Item.DamageType = DamageClass.Melee;
            Item.width = 128;
            Item.height = 128;
            Item.useTime = 10;
            Item.scale = 6f;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 7;
            Item.value = Item.sellPrice(gold: 75);
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.axe = 5000;
            Item.useTurn = true;
            Item.tileBoost = 50;
        }

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod mod))
            {
                Recipe recipe = CreateRecipe();
                ModContent.Find<ModItem>("Fargowiltas", "LumberJaxe");
                recipe.AddIngredient(ModContent.Find<ModItem>("Fargowiltas", "LumberJaxe"));
                recipe.AddIngredient(null, "True_Wood", 20);
                recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
                recipe.Register();
            }
        }
    }
}*/
