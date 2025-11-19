using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class BrokenHeroGun : ModItem
	{
		public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(gold: 9);
			Item.rare = ItemRarityID.Yellow;
		}
	}
}