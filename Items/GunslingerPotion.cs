using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
    public class GunslingerPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Increased ranged abilities on certain weapons");
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
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(silver: 10);
            Item.buffType = ModContent.BuffType<Buffs.GunslingersDelight>();
            Item.buffTime = 36000;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<GunslingerPotion>());
            recipe.AddIngredient(ModContent.ItemType<ArsonPotion>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RocketPotion>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BulletSteroids>(), 1);
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.AddIngredient(ItemID.Blinkroot, 1);
            recipe.AddIngredient(ItemID.ArcheryPotion, 2);
            recipe.AddIngredient(ItemID.MusketBall, 50);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}