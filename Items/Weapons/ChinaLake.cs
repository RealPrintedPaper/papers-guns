using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ChinaLake : ModItem
	{


		//Stats
		public override void SetDefaults()
		{
			Item.damage = 25;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 88;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.GrenadeI;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (Main.rand.NextBool())
			{
				type = ModContent.ProjectileType<Projectiles.HolyGrenade>();
			}
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ChinaLake>());
			recipe.AddIngredient(ItemID.HallowedBar, 18);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();

		}
	}
}