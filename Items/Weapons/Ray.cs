using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class Ray : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ray Gun");
			// Tooltip.SetDefault("Shoots a powerful ray beam\n'Revive me I have Ray Gun!'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.HeatRay);
			Item.rare = ItemRarityID.Cyan;
			Item.damage = 110;
			Item.useTime *= 2;
			Item.useAnimation *= 2;
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.UseSound = new SoundStyle("PapersGuns/Sounds/raygunshoot") with { Volume = 0.4f };
			Item.useAmmo = ModContent.ItemType<PhotonCell>();
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.NormalRay>();
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, 4);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Ray>());
			recipe.AddIngredient(ItemID.HeatRay);
			recipe.AddIngredient(ModContent.ItemType<FreezeRay>());
			recipe.AddIngredient(ModContent.ItemType<LaserPistolII>());
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>(), 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}