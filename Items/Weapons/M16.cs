using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class M16 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("20% chance to not consume ammo\n'I ain't no fortunate one'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ModContent.ItemType<M14>());
			Item.damage = 30;
			Item.rare = ItemRarityID.Lime;
			Item.value = Item.sellPrice(gold: 8);
			Item.useTime = 5;
			Item.useAnimation = Item.useTime * 3;
			Item.reuseDelay = 10;
			Item.UseSound = SoundID.Item31;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .20f;
		}
		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 2);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(3));
		}
	}
}