using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class HeadlessHorsemansHeadHunter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Headless Horseman's Head Hunter");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.JackOLantern;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.FlamingJack;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}


		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HeadlessHorsemansHeadHunter>());
			recipe.AddIngredient(ItemID.TheHorsemansBlade, 1);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}