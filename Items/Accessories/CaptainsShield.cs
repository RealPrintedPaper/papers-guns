using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace PapersGuns.Items.Accessories
{
	[AutoloadEquip(EquipType.Back)]
	public class CaptainsShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Captain's Shield");
			// Tooltip.SetDefault("Grants immunity to knockback and fire blocks\nGrants immunity to most debuffs\n50% damage reduction from enemies that attack from behind\n'The Captain is here!'\n");
		}

		//Stats
        public override void SetDefaults()
        {
			Item.width = 40;
			Item.height = 20;
			Item.accessory = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.sellPrice(gold:10);
			Item.defense = 6;
        }
		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<CaptainsShield>());
			recipe.AddIngredient(ModContent.ItemType<RiotShield>());
			recipe.AddIngredient(ItemID.AnkhShield);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.Register();
		}
		//Effect
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.GetModPlayer<PGPlayer>().captainshield = true;
			player.fireWalk = true;
			player.noKnockback = true;

			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Chilled] = true;
		}
	}
}