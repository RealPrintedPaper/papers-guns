using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ReptilianRupture : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 8f;
			Item.useAmmo = ItemID.Gel;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			int rot = Main.rand.Next(-35, 35);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
			type = ProjectileID.Flames;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ReptilianRupture>());
			recipe.AddIngredient(ItemID.Flamethrower);
			recipe.AddIngredient(ItemID.Gatligator);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}