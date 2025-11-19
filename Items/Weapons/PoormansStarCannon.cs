using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class PoormansStarCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Poor Man's Star Cannon");
			// Tooltip.SetDefault("Uses fallen stars for ammo\nYour shot has a chance to fail completely\n'It's not much, but it'll do.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.5f;
			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 15);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = ItemID.FallenStar;
			Item.crit = 21;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.PurificationPowder)
            {
				type = ProjectileID.FallingStar;
			}
			if (Main.rand.NextBool(3))
			{
				type = ProjectileID.None;
			}
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PoormansStarCannon>());
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}