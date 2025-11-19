using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class MiniNuke : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mini Nuke");
			// Tooltip.SetDefault("'Then, there was nothing.'\n");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.RocketI);
			Item.damage = 3000;
			Item.expert = true;
			Item.value = Item.buyPrice(platinum: 2);
			Item.ammo = ModContent.ItemType<MiniNuke>();
			Item.shoot = ModContent.ProjectileType<Projectiles.MiniNuke>();
		}
	}
}