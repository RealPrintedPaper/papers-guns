using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class HolyFlame : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\nShoots holy flame that speeds up over time, but weakens in damage every enemy hit\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 1f;
			Item.useAmmo = ItemID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 50f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			type = ModContent.ProjectileType<Projectiles.HolyFlame>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<HolyFlame>());
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}