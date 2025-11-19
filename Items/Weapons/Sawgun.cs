using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Sawgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into sawblades\n'Exported from SawCon'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item22;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.Sawblade>();
        }

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Sawgun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.CobaltChainsaw);
			recipe.AddIngredient(ItemID.SoulofNight, 2);
			recipe.AddIngredient(ItemID.SoulofLight, 2);
			recipe.AddRecipeGroup("IronBar", 15);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<Sawgun>());
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe2.AddIngredient(ItemID.PalladiumChainsaw);
			recipe2.AddIngredient(ItemID.SoulofNight, 2);
			recipe2.AddIngredient(ItemID.SoulofLight, 2);
			recipe2.AddRecipeGroup("IronBar", 15);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}