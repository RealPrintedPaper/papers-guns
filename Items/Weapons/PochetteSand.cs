using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class PochetteSand : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Throw sand at your enemies to confuse them\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 5;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(silver: 30);
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 5f;
			Item.useAmmo = AmmoID.Sand;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.Sand>();
		}

	}
}