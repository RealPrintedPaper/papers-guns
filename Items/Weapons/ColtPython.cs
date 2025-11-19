using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class ColtPython : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 12;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 17;
			Item.useAnimation = 17;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.buyPrice(gold: 7);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-1, 0);
		}
	}
}