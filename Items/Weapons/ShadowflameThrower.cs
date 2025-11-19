using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ShadowflameThrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns gel into shadowflames\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 27;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(gold: 2, silver: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item103;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.ShadowFlame;
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ShadowflameThrower>());
			recipe.AddIngredient(ModContent.ItemType<ShadowBolt>(), 1);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddRecipeGroup("IronBar", 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}