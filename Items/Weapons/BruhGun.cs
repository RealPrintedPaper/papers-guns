using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class BruhGun : ModItem
	{
		private int the = 0;
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 42;
			Item.height = 32;
			Item.useTime = 4;
			Item.useAnimation = Item.useTime * 4;
			Item.reuseDelay = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.sellPrice(silver: 50);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
			Item.consumeAmmoOnLastShotOnly = true;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			the += 1;
			if (the >= 4)
            {
				the = 0;
            }
			if (the == 1)
			{
				type = ModContent.ProjectileType<Projectiles.H>();

			}
			else if (the == 2)
			{
				type = ModContent.ProjectileType<Projectiles.U>();

			}
			else if (the == 3)
			{
				type = ModContent.ProjectileType<Projectiles.R>();

			}
			else
			{
				type = ModContent.ProjectileType<Projectiles.B>();

			}
		}
		public override void HoldItem(Player player)
		{
			Item.useAnimation = Item.useTime * 4;
		}

		public override bool CanUseItem(Player player)
		{
			the = 0;
			return true;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}
	}
}