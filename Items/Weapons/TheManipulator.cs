using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace PapersGuns.Items.Weapons
{
	public class TheManipulator : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots random projectiles at an extreme rate\nConsumes no ammo\n'You've come a long way. Now clean up this mess.'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 525;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 232;
			Item.height = 90;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 15;
			Item.value = Item.sellPrice(platinum: 10);
			Item.rare = ItemRarityID.Red;
			Item.expert = true;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 32f;
			Item.useAmmo = AmmoID.None;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			/*Vector2 muzzleOffset = Vector2.Normalize(velocity) * 150f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
				position.Y -= 10;
			}*/
			type = 0;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int numberProjectiles = 2 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				velocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				velocity = velocity * scale;
				Projectile.NewProjectile(source, position, velocity, Main.rand.Next(new int[] {1,2,3,4,5,6,7,9,12,14,15,19,20,21,22,24,27,30,
					33,36,45,48,51,52,54,76,77,78,85,88,89,91,92,93,95,103,104,106,113,114,116,117,118,119,120,121,122,123,124,125,126,132,133,134,139,140,150,156,157,158,159,
					160,161,162,163,166,167,168,169,170,172,173,181,183,189,195,206,207,221,227,228,229,239,242,245,246,248,253,254,260,261,263,265,267,272,274,278,279,280,
					282,283,284,285,286,287,304,306,310,311,312,316,320,321,323,330,333,335,336,337,338,340,343,357,359,374,376,378,389,399,400,401,402,408,410,424,425,426,440,
					442,444,451,469,474,477,478,479,483,485,495,495,496,502,503,507,510,520,521,522,523,524,532,597,598,599,616,617,638,639,660,661,668,680,700,706,709,710,711,
					712,}), damage, knockback, player.whoAmI); // theres probably a better way to do this but lol idk
			}

			SoundEngine.PlaySound(new SoundStyle("Terraria/Sounds/Item_" + Main.rand.Next(1, 125)), player.position);

			return false;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-50, -25);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TheManipulator>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 20);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 200);
			recipe.AddIngredient(ItemID.MusketBall, 7992);
			recipe.AddIngredient(ItemID.LunarBar, 75);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 150);
			recipe.AddIngredient(ModContent.ItemType<UltimateenergyofChaos>());
			recipe.AddIngredient(ModContent.ItemType<OmniChainGun>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

		}
	}
}