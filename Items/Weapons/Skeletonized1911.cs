using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class Skeletonized1911 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Skeletonized 1911");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Handgun);
			Item.damage -= 3;
			Item.crit += 2;
			Item.useTime -= 3;
			Item.useAnimation -= 3;
			Item.value = Item.sellPrice(gold: 5);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 2);
		}
	}
}