using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class M14 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("10% chance to not consume ammo\n'They're in the trees!'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .10f;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 2);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));
		}
	}
}