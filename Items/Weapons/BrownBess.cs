using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class BrownBess : ModItem
	{

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Musket);
			Item.damage += 5;
			Item.useTime += 3;
			Item.useAnimation += 3;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.sellPrice(gold: 5);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 2);
		}
	}
}