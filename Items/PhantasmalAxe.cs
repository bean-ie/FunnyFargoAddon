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
    internal class PhantasmalAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The axe of axes.");
        }
        public override void SetDefaults()
        {
            Item.damage = 94;
            Item.width = 32;
            Item.height = 28;
            Item.knockBack = 8;
            Item.useAnimation = 20;
            Item.useTime = 1;
            Item.axe = 5000 / 5;
            Item.tileBoost = 70;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Master;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Item.sellPrice(platinum: 10);
            Item.DamageType = DamageClass.Melee;
        }

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod mod))
            {
                Recipe recipe = CreateRecipe()
                    .AddIngredient(ModContent.ItemType<AxeOfNature>())
                    .AddIngredient(ModContent.ItemType<TerraAxe>())
                    .AddIngredient(ModContent.ItemType<PaulsAxe>())
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "EternalEnergy").Type, 15);
                recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
                recipe.Register();
            }
        }
    }
}
