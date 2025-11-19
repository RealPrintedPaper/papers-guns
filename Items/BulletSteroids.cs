using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PapersGuns.Items
{
    public class BulletSteroids : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("10% increased bullet damage\n'Your bullets have massive biceps'\n");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 15);
            Item.buffType = ModContent.BuffType<Buffs.BulletSteroids>();
            Item.buffTime = 14400;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<BulletSteroids>());
            recipe.AddIngredient(ItemID.MusketBall, 5);
            recipe.AddIngredient(ItemID.Blinkroot, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}