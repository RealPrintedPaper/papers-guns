using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class SpectreChaingun : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("50% chance to not consume ammo\nHighly innacurate...?");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.SpectreStaff);
			Item.damage /= 3;
			Item.knockBack = 2;
			Item.DamageType = DamageClass.Ranged;
			Item.mana = 0;
			Item.useTime /= 4;
			Item.useAnimation /= 4;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 4);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			int rot = Main.rand.Next(-25, 25);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
			type = ProjectileID.LostSoulFriendly;
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<SpectreChaingun>());
			recipe.AddIngredient(ItemID.SpectreStaff);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}