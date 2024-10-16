using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using FunnyFargoAddon.Projectiles;

namespace FunnyFargoAddon.Items
{
    internal class SparklingAppreciation : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<SparklingAppreciation_Projectile>(), 40, 2, 5);
            Item.shootSpeed = 5;
            Item.rare = ItemRarityID.Orange;
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'It appears to be unfinished'");
        }
        public override bool MeleePrefix()
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.BlandWhip)
                .AddIngredient(ItemID.PinkGel, 50)
                .AddIngredient(ItemID.VampireFrogStaff)
                .AddIngredient(ItemID.TatteredCloth, 4)
                .AddIngredient(ModContent.Find<ModItem>("FargowiltasSouls", "DeviatingEnergy"), 20)
                .Register();
        }
    }
}
