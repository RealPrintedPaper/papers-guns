using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class WaltherMP : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Walther MP");
			// Tooltip.SetDefault("20% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ModContent.ItemType<MP40>());
			Item.damage = 12;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(gold: 6);
		}

		//Ammo Consumption
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 2);
		}

		//Shooty Effects
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
		}
	}
}