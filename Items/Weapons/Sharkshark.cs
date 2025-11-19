using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class Sharkshark : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Turns rockets into sharks!\n'Unrelated to the Minishark and Megashark'");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.NPCDeath13;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 12f;
			Item.useAmmo = AmmoID.Rocket;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Projectiles.FriendlyShark>();
        }

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<Sharkshark>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 5);
			recipe.AddIngredient(ItemID.SharkFin, 7);
			recipe.AddIngredient(ModContent.ItemType<ForbiddenGunParts>());
			recipe.AddIngredient(ItemID.RocketLauncher);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}