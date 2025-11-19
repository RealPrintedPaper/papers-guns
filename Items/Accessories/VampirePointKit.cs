using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using System;

namespace PapersGuns.Items.Accessories
{
	public class VampirePointKit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Critical hits grants health\n");
		}


		//Stats
		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(gold: 2);
		}

        //Effect
        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<PGPlayer>().vampirepointkiton = true;
		}

    }
}