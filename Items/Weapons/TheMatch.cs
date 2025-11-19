using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class TheMatch : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Match");
			// Tooltip.SetDefault("Shoots a giant slow moving fireball with infinite piercing\nConsumes no ammo\n'Hell calls.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 666;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 290;
			Item.height = 108;
			Item.useTime = 120;
			Item.useAnimation = 120;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(platinum: 30);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item119;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 0.5f;
			Item.useAmmo = AmmoID.None;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 150f;
			position += muzzleOffset;
			type = ModContent.ProjectileType<Projectiles.HugeFireball>();
        }

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-70, -25);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheMatch>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 20);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 100);
			recipe.AddIngredient(ItemID.FragmentSolar, 500);
			recipe.AddIngredient(ItemID.LivingFireBlock, 500);
			recipe.AddIngredient(ItemID.LunarBar, 50);
			recipe.AddIngredient(ItemID.HellstoneBar, 250);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofHell>());
			recipe.AddIngredient(ModContent.ItemType<FireballLauncher>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}