using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Terrarupture : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Shoots a terrarocket beam");
        }
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 150;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 100;
			Item.value = Item.sellPrice(gold: 40);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item92;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.TerraRocket>();
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Terrarupture>());
			recipe.AddIngredient(ModContent.ItemType<TrueDeathValley>());
			recipe.AddIngredient(ModContent.ItemType<TrueChinaLake>());
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}