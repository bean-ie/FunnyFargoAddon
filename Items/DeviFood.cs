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
    public class DeviFood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emergency Ration");
            Tooltip.SetDefault("Minor improvements to all stats\n`Guess I was wrong...`");
        }

        public override void SetDefaults()
        {
            Item.height = 34;
            Item.width = 28;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(silver: 20);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item2;
            Item.buffType = BuffID.WellFed;
            Item.buffTime = 600;
        }

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("FargowiltasSouls", out Mod mod))
            {
                Recipe recipe = CreateRecipe();
                ModContent.TryFind<ModItem>("FargowiltasSouls", "ChibiHat", out ModItem item);
                recipe.AddIngredient(item.Type);
                recipe.AddTile(TileID.CookingPots);
                recipe.Register();
            }
        }
    }
}
