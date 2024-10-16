using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FunnyFargoAddon.Items
{
	public class FunnySword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Funny Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a basic funny sword.");
		}

		public override void SetDefaults()
		{
			Item.damage = 69;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Confetti, 420);
			recipe.AddIngredient(ItemID.SillyBalloonGreen, 69);
            recipe.AddIngredient(ItemID.SillyBalloonPink, 69);
            recipe.AddIngredient(ItemID.SillyBalloonPurple, 69);
            recipe.AddTile(TileID.CrystalBall);
			recipe.Register();
		}
	}
}