using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DigitRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into digits\nThe digit corresponds to how much it can pierce\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(8));
			type = Main.rand.Next(new int[] {ModContent.ProjectileType<Projectiles.Digits.Zero>(), 
				ModContent.ProjectileType<Projectiles.Digits.One>(), 
				ModContent.ProjectileType<Projectiles.Digits.Two>(), 
				ModContent.ProjectileType<Projectiles.Digits.Three>(), 
				ModContent.ProjectileType<Projectiles.Digits.Four>(), 
				ModContent.ProjectileType<Projectiles.Digits.Five>(), 
				ModContent.ProjectileType<Projectiles.Digits.Six>(), 
				ModContent.ProjectileType<Projectiles.Digits.Seven>(), 
				ModContent.ProjectileType<Projectiles.Digits.Eight>(), 
				ModContent.ProjectileType<Projectiles.Digits.Nine>() });
        }

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DigitRifle>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.SoulofLight, 5);
			recipe.AddIngredient(ModContent.ItemType<BinaryPistol>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}