using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class UmbrellaGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shooting upwards will give you slow falling");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 80;
			Item.height = 46;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 8f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}


        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			if (player.itemRotation > MathHelper.ToRadians(60) || player.itemRotation < MathHelper.ToRadians(-60))
			{
				player.AddBuff(BuffID.Featherfall, 21);
			}
        }

        //Crafting Recipe
        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<UmbrellaGun>());
			recipe.AddIngredient(ItemID.Umbrella);
			recipe.AddRecipeGroup("IronBar", 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}