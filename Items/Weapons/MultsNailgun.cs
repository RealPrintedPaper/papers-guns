using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class MultsNailgun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("MUL-T's Nailgun");
			// Tooltip.SetDefault("15% chance to not consume ammo\n" + "'OK. Everything checks out. You're free to go, pal.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = 8;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.NailFriendly;
			Item.crit = 5;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .15f;
		}

        //Shooty Effects
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 1 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MultsNailgun>());
			recipe.AddIngredient(ItemID.NailGun, 2);
			recipe.AddIngredient(ItemID.Ectoplasm, 5);
			recipe.AddIngredient(ItemID.Megashark, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}