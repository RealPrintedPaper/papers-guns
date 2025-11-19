using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class TheCrystallineCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			/* Tooltip.SetDefault("Shoots a large geode that explodes into large gems\n" +
				"Large rubies heal on hit\n" +
				"Large amethysts inflict a special debuff and pierce some enemies\n" +
				"Large sapphires go through walls\n" +
				"Large emeralds give you a special buff\n" +
				"Large topazes explode into many shards on impact\n" +
				"Large amber explode on impact\n" +
				"Large diamonds pierce infinitely\n" +
				"Consumes no ammo\n" +
				"'Pelt your enemies with the world's riches.'"); */
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 470;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 256;
			Item.height = 96;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(platinum: 15);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 32f;
			Item.useAmmo = AmmoID.None;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			/*Vector2 muzzleOffset = Vector2.Normalize(velocity) * 150f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
				position.Y -= 20;
			}*/
			type = ModContent.ProjectileType<Projectiles.LargeGeode>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-50, -20);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheCrystallineCannon>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 20);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 75);
			recipe.AddIngredient(ItemID.LunarBar, 77);
			recipe.AddIngredient(ItemID.HallowedBar, 150);
			recipe.AddIngredient(ItemID.Boulder, 3996);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofLight>());
			recipe.AddIngredient(ModContent.ItemType<GemLauncher>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

		}
	}
}