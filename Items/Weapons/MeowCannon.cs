using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class MeowCannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots cats!\n90% chance to not consume ammo");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.3f;
			Item.damage = 200;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 11;
			Item.value = Item.sellPrice(gold: 70);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item68;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = ItemID.FallenStar;
			Item.crit = 46;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .9f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity.RotatedByRandom(MathHelper.ToRadians(9));
			if (type == ProjectileID.PurificationPowder)
			{
				type = ProjectileID.Meowmere;
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<MeowCannon>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.Meowmere, 2);
			recipe.AddIngredient(ItemID.StarCannon, 5);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.FragmentVortex, 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}