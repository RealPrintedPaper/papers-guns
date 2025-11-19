using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace PapersGuns.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class GunWings : ModItem
	{
        private IEntitySource source;
		float winginterval;
		int timer;

        public override void SetStaticDefaults()
		{
			ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(250, 20f, 5f);
		}

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = Item.sellPrice(platinum:5);
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
			Item.accessory = true;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising, ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.9f;
			ascentWhenRising = 0.2f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 5f;
			constantAscend = 0.15f;
		}
        public override bool WingUpdate(Player player, bool inUse)
        {
			if (inUse)
			{
				timer++;

				Vector2 velocity = new Vector2(12, 0);
				winginterval += 0.1f;
				if (timer % 2 == 0)
				{
					SoundEngine.PlaySound(SoundID.Item11, player.position);
					for (int i = 0; i < 2; i++)
					{
						float f = (float)Math.Sin(winginterval + i) * 30;
						velocity = velocity.RotatedBy(MathHelper.ToRadians(f));
						Projectile.NewProjectile(source, player.position + new Vector2(player.width / 2 + 10, player.height / 2), velocity, ModContent.ProjectileType<Projectiles.HallowPointBulletShot>(), 1337, 5, player.whoAmI);
						Projectile.NewProjectile(source, player.position + new Vector2(player.width / 2 - 10, player.height / 2), new Vector2(-velocity.X, velocity.Y), ModContent.ProjectileType<Projectiles.HallowPointBulletShot>(), 1337, 5, player.whoAmI);
					}
				}
            }
			return false;
        }

        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GunWings>());
			recipe.AddIngredient(ItemID.LunarBar, 25);
			recipe.AddIngredient(ItemID.GoldBar, 50);
			recipe.AddIngredient(ItemID.FragmentVortex, 35);
			recipe.AddIngredient(ItemID.SoulofFlight, 20);
			recipe.AddIngredient(ModContent.ItemType<EnergyFragment>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<GunWings>());
			recipe2.AddIngredient(ItemID.LunarBar, 25);
			recipe2.AddIngredient(ItemID.PlatinumBar, 50);
			recipe2.AddIngredient(ItemID.FragmentVortex, 35);
			recipe2.AddIngredient(ItemID.SoulofFlight, 20);
			recipe2.AddIngredient(ModContent.ItemType<EnergyFragment>(), 10);
			recipe2.AddIngredient(ModContent.ItemType<ArmsLordsEssense>(), 50);
			recipe2.AddTile(TileID.LunarCraftingStation);
			recipe2.Register();
		}
	}
}