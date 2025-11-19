using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items
{
	public class ArmsLordsEssense : ModItem
	{
		public override string Texture => "PapersGuns/Items/EnergyFragment";
		public override void SetStaticDefaults()
        {
			// DisplayName.SetDefault("Arms Lord's Essense");
			// Tooltip.SetDefault("'Why he cause so much destruction? Was it greed? Did he have a goal? Or maybe there was no reason at all...'\n");
        }
        public override void SetDefaults()
		{
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 99;
			Item.value = Item.sellPrice(gold:25);
			Item.rare = ItemRarityID.Purple;
			Item.expert = true;
		}
	}
}