using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
    public class ArsonPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("10% increased flamethrower damage\n");
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
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 15);
            Item.buffType = ModContent.BuffType<Buffs.ArsonistsRage>();
            Item.buffTime = 14400;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<ArsonPotion>());
            recipe.AddIngredient(ItemID.Fireblossom, 1);
            recipe.AddIngredient(ItemID.Gel, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}