using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ShadowBolt: ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into shadowflames\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.buyPrice(gold: 1, silver: 25);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item72;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.ShadowFlame;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ShadowBolt>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddRecipeGroup("IronBar", 25);
			recipe.AddIngredient(ItemID.IllegalGunParts, 1);
			recipe.AddIngredient(ItemID.Harpoon, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}