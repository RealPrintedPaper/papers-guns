using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class PaperGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into paper\n15% chance to not consume ammo\n'papo'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 32;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(gold: 6);
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item39;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .15f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-3, 0);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = 712;
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(6));
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<PaperGun>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.BookStaff);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}