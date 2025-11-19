using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Glock17 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glock 17");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
	}
}