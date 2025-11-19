using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Gewehr98 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Gewehr 98");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 2);
		}
	}
}