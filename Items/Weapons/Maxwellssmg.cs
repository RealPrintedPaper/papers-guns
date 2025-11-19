using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using System;

namespace PapersGuns.Items.Weapons
{
	public class Maxwellssmg : ModItem
	{
		private double rot = 0;
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Maxwell's SMG");
			// Tooltip.SetDefault("10% chance to not consume ammo\nUses photon cells\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 0.8f;
			Item.damage = 17;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = Item.useTime * 3;
			Item.reuseDelay = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 1;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = new SoundStyle("PapersGuns/Sounds/maxwellgun");
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
			Item.consumeAmmoOnLastShotOnly = true;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .10f;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 8);
        }

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            type = ProjectileID.LaserMachinegunLaser;

			if (player.direction == 1)
			{
				if (rot < -Math.PI)
				{
					rot = 0;
				}
				rot -= Math.PI / 2;
			}
			else
			{
				if (rot > Math.PI)
				{
					rot = 0;
				}
				rot += Math.PI / 2;
			}
			float f = (float)Math.Sin(rot) * 4;
			player.itemRotation += MathHelper.ToRadians(f);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(f));
		}

        public override void HoldItem(Player player)
        {
			Item.useAnimation = Item.useTime * 3;
		}
		
        public override bool CanUseItem(Player player)
        {
			rot = 0;
			return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Maxwellssmg>());
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.PlatinumBar, 10);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}