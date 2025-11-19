using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class PotatoCannon : ModItem
	{
		public override void SetStaticDefaults()
		{;
			// Tooltip.SetDefault("Uses potatos for ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 41;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 15);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Projectiles.Potatop>();
			Item.shootSpeed = 16f;
			Item.useAmmo = ModContent.ItemType<Potato>();
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 20f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-40, 5);
		}
	}
}