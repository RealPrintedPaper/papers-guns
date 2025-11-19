using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class TheMidasTouch : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots a midas bullet that turns enemies into gold\nDoes not affect boss enemies\nConsumes no ammo\n'Take back what's yours.'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 116;
			Item.height = 66;
			Item.useTime = 55;
			Item.useAnimation = 55;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(platinum: 15);
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.None;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.MidasBullet>();
        }

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 20);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheMidasTouch>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 25);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 10);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofGreed>());
			recipe.AddIngredient(ModContent.ItemType<GoldenDeagle>());
			recipe.AddIngredient(ItemID.GoldBar, 99 * 40);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}