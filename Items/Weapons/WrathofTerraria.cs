using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class WrathofTerraria : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Wrath of Terraria");
			// Tooltip.SetDefault("Uses gel for ammo\nShoots a wrathflame that slows down and deals more damage over time\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = ItemID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.WrathFlame>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<WrathofTerraria>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 5);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ModContent.ItemType<Aquathrower>());
			recipe.AddIngredient(ModContent.ItemType<Aneurysm>());
			recipe.AddIngredient(ModContent.ItemType<Wildfire>());
			recipe.AddIngredient(ModContent.ItemType<BreathoftheFallen>());
			recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<WrathofTerraria>());
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>(), 5);
			recipe2.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe2.AddIngredient(ModContent.ItemType<Aquathrower>());
			recipe2.AddIngredient(ModContent.ItemType<VileSpitter>());
			recipe2.AddIngredient(ModContent.ItemType<Wildfire>());
			recipe2.AddIngredient(ModContent.ItemType<BreathoftheFallen>());
			recipe2.AddTile(TileID.DemonAltar);
			recipe2.Register();
		}
	}
}