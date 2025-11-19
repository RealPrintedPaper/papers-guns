using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class MakeshiftFlamethrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Make-Shift Flamethrower");
			// Tooltip.SetDefault("Uses gel for ammo\n'This could get quite messy.'\nSmall chance to light the player on fire\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 6f;
			Item.useAmmo = ItemID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (Main.rand.Next(32) == 0)
            {
				player.AddBuff(BuffID.OnFire, 60);
            }
			type = ProjectileID.Flames;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MakeshiftFlamethrower>());
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddRecipeGroup("IronBar", 30);
			recipe.AddRecipeGroup("Wood", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}