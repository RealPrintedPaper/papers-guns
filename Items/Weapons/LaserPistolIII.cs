using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class LaserPistolIII : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Laser Pistol III");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 53;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 9;
			Item.value = Item.buyPrice(gold: 25);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item91;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.BlueLaserIII>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserPistolIII>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
			recipe.AddIngredient(ItemID.ShroomiteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ModContent.ItemType<LaserPistolII>(), 1);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddTile(TileID.Autohammer);
			recipe.Register();
		}
	}
}