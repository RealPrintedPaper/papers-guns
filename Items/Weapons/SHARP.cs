using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class SHARP : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("S.H.A.R.P.");
			// Tooltip.SetDefault("Shoots a 'super High Altitude Research Project' round\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 3000;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 9999;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item14;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.SharpShot>();
        }
    }
}