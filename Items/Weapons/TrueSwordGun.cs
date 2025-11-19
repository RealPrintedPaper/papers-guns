using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class TrueSwordGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns bullets into True Excalibur and Night's Edge beams\nYou can hurt nearby enemies with your Sword Gun\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.scale = 1.3f;
			Item.damage = 30;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = false;
			Item.knockBack = 6;
			Item.value = Item.sellPrice(gold: 10);
			Item.rare = ItemRarityID.Yellow;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.UseSound = SoundID.Item43;
			Item.shootSpeed = 18f;
			Item.useAmmo = AmmoID.Bullet;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.LightBeam;
			type = Main.rand.Next(new int[] { type, ProjectileID.NightBeam });
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-16, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<TrueSwordGun>());
			recipe.AddIngredient(ModContent.ItemType<SwordGun>());
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}