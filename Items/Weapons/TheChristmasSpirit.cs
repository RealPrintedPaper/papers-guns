using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items.Weapons
{
	public class TheChristmasSpirit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("The Christmas Spirit");
			/* Tooltip.SetDefault("Shoots a nice present or a naughty present\n" +
				"Nice presents shoot healthy crystals that heals you\n" +
				"Naughty presents burst into flames\n" +
				"Consumes no ammo\n'See who is naughty or nice, but all shall perish.'\n"); */
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 4500;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 290;
			Item.height = 108;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(platinum: 25);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item66;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.None;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = Main.rand.Next(new int[] {ModContent.ProjectileType<Projectiles.NicePresent>(), ModContent.ProjectileType<Projectiles.NaughtyPresent>()});
        }

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-50, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheChristmasSpirit>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 10);
			recipe.AddIngredient(ItemID.IllegalGunParts, 30);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 150);
			recipe.AddIngredient(ItemID.CandyCaneBlock, 999);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofHell>());
			recipe.AddIngredient(ModContent.ItemType<CandycaneThrower>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}