using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class ChlorophytePuffer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Uses gel for ammo\n40% chance to not consume ammo\n'WARNING: Do not inhale emitted gas.'\n");
		}

		//Stats
		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 6;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = Item.sellPrice(gold: 8);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item16;
			Item.autoReuse = true;
			Item.shoot = 10;
			Item.shootSpeed = 7f;
			Item.useAmmo = ItemID.Gel;
			Item.crit = 21;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .4f;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ProjectileID.SporeGas;
			type = Main.rand.Next(new int[] { type, ProjectileID.SporeGas2, ProjectileID.SporeGas3 });
			velocity = velocity.RotatedByRandom(MathHelper.ToRadians(12));
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 60f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<ChlorophytePuffer>());
			recipe.AddIngredient(ModContent.ItemType<MatterTransformer>(), 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}