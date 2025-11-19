using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class DustBubbler : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Shoots dust bubbles\n");
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
			Item.value = Item.sellPrice(silver: 25);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item85;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 6f;
			Item.useAmmo = AmmoID.None;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			float scale = 1f - (Main.rand.NextFloat() * .5f);
			velocity = velocity * scale;
			velocity = velocity + perturbedSpeed;
			type = ModContent.ProjectileType<Projectiles.DustBubble>();
			Item.UseSound = Main.rand.Next(new Terraria.Audio.SoundStyle[] {SoundID.Item85, SoundID.Item86, SoundID.Item87});
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, 3);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<DustBubbler>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe.AddIngredient(ItemID.CobaltBar, 15);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
			recipe.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			Recipe recipe2 = Recipe.Create(ModContent.ItemType<DustBubbler>());
			recipe2.AddIngredient(ModContent.ItemType<MatterTransformer>());
			recipe2.AddIngredient(ItemID.AncientBattleArmorMaterial);
			recipe2.AddIngredient(ItemID.PalladiumBar, 15);
			recipe2.AddIngredient(ItemID.SoulofNight, 5);
			recipe2.AddIngredient(ItemID.IllegalGunParts, 2);
			recipe2.AddTile(TileID.Anvils);
			recipe2.Register();
		}
	}
}