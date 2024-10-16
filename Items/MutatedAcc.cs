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
    public class MutatedAcc : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mutated Eye");
            Tooltip.SetDefault("Effects of the accessories dropped by the mutated siblings.\n`It's mutatin' time`");
        }

        public override void SetDefaults()
        {
            Item.height = 22;
            Item.width = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.sellPrice(1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod mod))
            {
                ModContent.Find<ModItem>("FargowiltasSouls", "MutantEye").UpdateAccessory(player, hideVisual);
                ModContent.Find<ModItem>("FargowiltasSouls", "AbominableWand").UpdateAccessory(player, hideVisual);
                ModContent.Find<ModItem>("FargowiltasSouls", "SparklingAdoration").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "SparklingAdoration").Type);
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "AbominableWand").Type);
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "MutantEye").Type);
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "AbomEnergy").Type, 10);
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "DeviatingEnergy").Type, 10);
            recipe.AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "EternalEnergy").Type, 10);
            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
            recipe.Register();
        }
    }
}
