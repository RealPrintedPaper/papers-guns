using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
    public class ShroomitePotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Gives the same powers as Shroomite armor\n");
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
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(silver: 15);
            Item.buffType = ModContent.BuffType<Buffs.ShroomiteStealth>();
            Item.buffTime = 7200;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<ShroomitePotion>());
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.AddIngredient(ItemID.ChlorophyteOre, 2);
            recipe.AddIngredient(ItemID.GlowingMushroom, 6);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}