using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Minigun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("66% chance to not consume ammo\n'Try turning the safety off!'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.3f;
			Item.damage = 150;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 2;
			Item.useAnimation = 2;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 40);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item40;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 32f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 10;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .66f;
		}

		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));
			if (player.altFunctionUse == 2)
			{
				if (type != ProjectileID.ExplosiveBullet)
				{
					type = ProjectileID.ExplosiveBullet;
				}
			}
		}

		//Secondary Use
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useTime = 4;
				Item.useAnimation = 4;
				Item.damage = 300;
				Item.shoot = ProjectileID.ExplosiveBullet;
			}
			else
			{
				Item.useTime = 2;
				Item.useAnimation = 2;
				Item.damage = 150;
				Item.shoot = ProjectileID.Bullet;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-6, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Minigun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.SDMG, 5);
			recipe.AddIngredient(ItemID.ChainGun, 5);
			recipe.AddIngredient(ItemID.VortexBeater, 5);
			recipe.AddIngredient(ItemID.Minishark, 5);
			recipe.AddIngredient(ItemID.Megashark, 5);
			recipe.AddIngredient(ItemID.Uzi, 1);
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.FragmentNebula, 5);
			recipe.AddIngredient(ItemID.FragmentSolar, 5);
			recipe.AddIngredient(ItemID.FragmentStardust, 5);
			recipe.AddIngredient(ItemID.FragmentVortex, 45);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}