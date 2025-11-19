using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class LaserPistol : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item91;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.BlueLaser>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<LaserPistol>());
			recipe.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe.AddIngredient(ItemID.PlatinumBar, 15);
			recipe.AddIngredient(ItemID.Sapphire, 4);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<LaserPistol>());
			recipe2.AddIngredient(ItemID.MeteoriteBar, 5);
			recipe2.AddIngredient(ItemID.GoldBar, 15);
			recipe2.AddIngredient(ItemID.Sapphire, 4);
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe2.AddIngredient(ModContent.ItemType<Diode>(), 5);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}