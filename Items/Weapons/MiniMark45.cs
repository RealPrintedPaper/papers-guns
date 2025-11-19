using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class MiniMark45 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mini Mark 45");
			// Tooltip.SetDefault("Shoots a high velocity explosive round\n'This was attached to a warship, how did you get this??'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 50;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item73;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.DestroyerShot>();
        }
    }
}