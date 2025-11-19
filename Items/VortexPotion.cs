using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
    public class VortexPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Gives a massive boost in ranged abilities, but you become distorted and sick\n'Should you drink this stuff anyways?'\n");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.value = Item.sellPrice(silver: 15);
            Item.buffType = ModContent.BuffType<Buffs.Vortexed>();
            Item.buffTime = 1800;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<VortexPotion>());
            recipe.AddIngredient(ItemID.VortexDye, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}