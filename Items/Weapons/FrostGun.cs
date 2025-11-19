using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class FrostGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses snowballs for ammo\nShoots a high speed icicle\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 13;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = ItemID.Snowball;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.Blizzard;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FrostGun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.Snowball, 25);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.IceBlock, 50);
			recipe.AddTile(TileID.IceMachine);
			recipe.Register();
		}
	}
}