using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Galil : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("'Not automatic'\n");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 9);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 16f;
			Item.useAmmo = AmmoID.Bullet;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 2);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(2));
		}
	}
}