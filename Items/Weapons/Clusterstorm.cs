using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class Clusterstorm : ModItem
	{
		public override void SetStaticDefaults()
		{
			/* Tooltip.SetDefault("Shoots grenades from the sky\n" +
				"15% chance to not consume ammo\n"); */
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 86;
			Item.height = 54;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.GrenadeI;
			Item.shootSpeed = 24f;
			Item.useAmmo = AmmoID.Rocket;
			Item.crit = 46;
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
				position = new Vector2(player.position.X - (player.position.X - Main.MouseWorld.X) / 1.5f + Main.rand.Next(-300, 300), player.position.Y + Main.rand.Next(-100, 100) - 600);
				velocity.X *= 0.2f + Main.rand.NextFloat(-0.1f,0.1f);
				velocity.Y = 15;
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(7));
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			}
			return false;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, -5);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Clusterstorm>());
			recipe.AddIngredient(ItemID.GrenadeLauncher);
			recipe.AddIngredient(ItemID.DaedalusStormbow);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}