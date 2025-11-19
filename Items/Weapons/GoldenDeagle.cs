using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class GoldenDeagle : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 344;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 16;
			Item.value = Item.buyPrice(platinum: 25);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Bullet;
			Item.expert = true;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}
	}
}