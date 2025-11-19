using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class L85A2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("L85A2");
			// Tooltip.SetDefault("25% chance to not consume ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ModContent.ItemType<Type63>());
			Item.damage = 20;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(gold: 6);
		}

		//Ammo Consumption
		public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .25f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 2);
		}

		//Shooty Effects
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(4));
		}
	}
}