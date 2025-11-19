using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;

namespace PapersGuns.Items.Weapons
{
	public class AmberPistol : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into amber bolts \n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmberStaff);
			Item.damage += 7;
			Item.mana = 0;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.UseSound = SoundID.Item11;
			Item.shoot = 10;
			Item.useAmmo = AmmoID.Bullet;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.AmberBolt;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-2, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<AmberPistol>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.Amber, 8);
			recipe.AddIngredient(ItemID.FossilOre, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}