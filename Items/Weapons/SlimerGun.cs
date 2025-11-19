using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class SlimerGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n15% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 68;
			Item.height = 46;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item95;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 20f;
			Item.useAmmo = AmmoID.Gel;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.Slimey>();
        }

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .15f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-7, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<SlimerGun>());
			recipe.AddIngredient(ItemID.SlimeGun, 2);
			recipe.AddIngredient(ItemID.SlimeBlock, 10);
			recipe.AddTile(TileID.Solidifier);
			recipe.Register();
		}
	}
}