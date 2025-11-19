using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class MusketwithaBayonet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Musket With a Bayonet");
			// Tooltip.SetDefault("You can swing your gun using alternate fire\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 5.25f;
			Item.value = Item.sellPrice(gold: 2);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 9f;
			Item.useAmmo = AmmoID.Bullet;
			Item.crit = 7;
		}

		//Able to use right click
		public override bool AltFunctionUse(Terraria.Player player)
		{
			return true;
		}

		//Secondary Use
		public override bool CanUseItem(Terraria.Player player)
		{
			if (player.altFunctionUse == 2)
			{
				Item.useStyle = ItemUseStyleID.Swing;
				Item.noMelee = false;
				Item.UseSound = SoundID.Item1;
				Item.shoot = ProjectileID.None;
			}
			else
			{
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.DamageType = DamageClass.Ranged;
				Item.noMelee = true;
				Item.UseSound = SoundID.Item11;
				Item.shoot = AmmoID.Bullet;
			}
			return base.CanUseItem(player);
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-8, -2);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<MusketwithaBayonet>());
			recipe.AddIngredient(ItemID.IronShortsword, 1);
			recipe.AddIngredient(ItemID.Musket, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}