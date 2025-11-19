using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class PyromaniacsFlamethrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n'Huddah huddah huh!'\nMinimal chance to light the player on fire\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 9;
			Item.useAnimation = 9;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 8f;
			Item.useAmmo = ItemID.Gel;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (Main.rand.Next(149) == 0)
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
			Recipe recipe = Recipe.Create(ModContent.ItemType<PyromaniacsFlamethrower>());
			recipe.AddIngredient(ModContent.ItemType<MakeshiftFlamethrower>());
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ItemID.PalladiumBar, 15);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();


			Recipe recipe2 = Recipe.Create(ModContent.ItemType<PyromaniacsFlamethrower>());
			recipe2.AddIngredient(ModContent.ItemType<MakeshiftFlamethrower>());
			recipe2.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe2.AddIngredient(ItemID.CobaltBar, 15);
			recipe2.AddRecipeGroup("IronBar", 10);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}