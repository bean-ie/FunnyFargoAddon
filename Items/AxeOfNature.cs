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
    internal class AxeOfNature : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'And they run when the sun comes up, with their lives on the line'");
        }
        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.width = 36;
            Item.height = 32;
            Item.knockBack = 5;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.axe = 110 / 5;
            Item.tileBoost = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.value = Item.sellPrice(gold: 4);
            Item.DamageType = DamageClass.Melee;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe()
                .AddIngredient(ItemID.CopperAxe)
                .AddIngredient(ItemID.TinAxe)
                .AddIngredient(ItemID.IronAxe)
                .AddIngredient(ItemID.LeadAxe)
                .AddIngredient(ItemID.SilverAxe)
                .AddIngredient(ItemID.TungstenAxe)
                .AddIngredient(ItemID.GoldAxe)
                .AddIngredient(ItemID.PlatinumAxe)
                .AddIngredient(ItemID.WarAxeoftheNight)
                .AddIngredient(ItemID.BloodLustCluster)
                .AddIngredient(ItemID.MoltenHamaxe)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
