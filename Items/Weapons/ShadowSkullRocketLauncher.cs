using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ShadowSkullRocketLauncher : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Shoots shadowflame skulls\n");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 6);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item38;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.ClothiersCurse;
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ShadowSkullRocketLauncher>());
			recipe.AddIngredient(ItemID.Bone, 35);
			recipe.AddIngredient(ItemID.Cobweb, 70);
			recipe.AddRecipeGroup("IronBar", 10);
			recipe.AddIngredient(ItemID.IllegalGunParts);
			recipe.AddIngredient(ItemID.ClothierVoodooDoll);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

		}
	}
}