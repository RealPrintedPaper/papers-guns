using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Rpg7 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("RPG 7");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 42;
			Item.useAnimation = 42;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(gold: 65);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.RocketI;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Rocket;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, -4);
		}
	}
}