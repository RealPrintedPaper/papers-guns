using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class Rocket0 : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rocket 0");
			// Tooltip.SetDefault("'Usually, an orange tip means its a toy.'\n");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.RocketI);
			Item.damage = 5;
		}
	}
}