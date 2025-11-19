using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class JewelWeed : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Direct hits inflict poisoned\nShoots jewelweed bombs that explode into seeds\n");
        }
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 4;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.JewelWeedSeed>();
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-5, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<JewelWeed>());
			recipe.AddIngredient(ItemID.JungleSpores, 20);
			recipe.AddIngredient(ItemID.Vine, 8);
			recipe.AddIngredient(ItemID.RichMahogany, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

		}
	}
}