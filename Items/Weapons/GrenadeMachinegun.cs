using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class GrenadeMachinegun : ModItem
	{
		//Stats
		public override void SetDefaults()
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 88;
			Item.height = 32;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = Item.sellPrice(gold: 15);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.GrenadeI;
			Item.shootSpeed = 10f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(5));
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GrenadeMachinegun>());
			recipe.AddIngredient(ItemID.GrenadeLauncher, 2);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.Ectoplasm, 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}