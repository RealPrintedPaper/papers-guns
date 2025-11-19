using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace PapersGuns.Items.Weapons
{
	public class GatliDarter : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("50% chance to not consume ammo\n'Just a heads up, this weapon is nerfed when using ichor darts.'\n");
        }

        //Stats
        public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 5;
			Item.useAnimation = 5;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PoisonDart;
			Item.shootSpeed = 25f;
			Item.useAmmo = AmmoID.Dart;
		}

        //Ammo Consumption
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

		//Position Fix
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			//if (type == ProjectileID.IchorDart)
			{
				//Item.damage = 7;
			}
			//else
			{
				//Item.damage = 35;
			}
			int rot = Main.rand.Next(-7, 7);
			player.itemRotation += MathHelper.ToRadians(rot);
			velocity = velocity.RotatedBy(MathHelper.ToRadians(rot));
		}

		//Crafting Recipe
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<GatliDarter>());
			recipe.AddIngredient(ItemID.DartRifle);
			recipe.AddIngredient(ItemID.DartPistol);
			recipe.AddIngredient(ItemID.FragmentVortex, 5);
			recipe.AddIngredient(ModContent.ItemType<BrokenHeroGun>());
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}