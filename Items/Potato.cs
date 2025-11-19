using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
	public class Potato : ModItem
	{

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.value = Item.buyPrice(copper: 10);
			Item.rare = ItemRarityID.Blue;
			Item.shoot = ModContent.ProjectileType<Projectiles.Potatop>();
			Item.ammo = ModContent.ItemType<Potato>();
		}
	}
}