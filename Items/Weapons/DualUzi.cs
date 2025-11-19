using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class DualUzi : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a powerful, high velocity bullet\n'Not cool, Butthead.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Uzi);
			Item.damage = 20;
			Item.useTime = 4;
			Item.useAnimation = 4;
			Item.value = Item.sellPrice(gold: 14);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 2);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
		}
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DualUzi>());
			recipe.AddIngredient(ItemID.Uzi, 2);
			recipe.Register();
		}
	}
}