using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class GrenadeEater : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Direct hits inflict cursed inferno");
        }
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.DemonGrenade>();
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GrenadeEater>());
			recipe.AddIngredient(ItemID.DemoniteBar, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddIngredient(ItemID.RottenChunk, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}