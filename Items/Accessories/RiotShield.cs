using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class RiotShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Grants immunity to knockback\n33% damage reduction from enemies that attack from behind\n'DINK DINK DINK'\n");
		}

		//Stats
        public override void SetDefaults()
        {
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(gold:6);
			Item.defense = 4;
        }

		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<PGPlayer>().riotshield = true;
			player.noKnockback = true;
        }
	}
}