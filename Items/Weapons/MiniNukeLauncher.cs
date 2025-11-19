using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class MiniNukeLauncher : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 3000;
			Item.expert = true;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 500;
			Item.value = Item.buyPrice(platinum: 200);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.MiniNuke>();
			Item.shootSpeed = 18f;
			Item.useAmmo = ModContent.ItemType<MiniNuke>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-90, -4);
		}
	}
}