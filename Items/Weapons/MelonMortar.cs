using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class MelonMortar : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns rockets into melons\nShoots a melon upwards then towards the cursor\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(silver: 20);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.Melon>();
			velocity = new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-11, -9));
			if (player.direction == 1)
            {
				position += new Vector2(30, 0);
            }
			else
            {
				position += new Vector2(-30, 0);
            }
		}
        //Crafting Recipe
        public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MelonMortar>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 2);
			recipe.AddIngredient(ItemID.TrashCan);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}