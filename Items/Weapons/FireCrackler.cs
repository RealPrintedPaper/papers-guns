using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;

namespace PapersGuns.Items.Weapons
{
	public class FireCrackler : ModItem
	{
        public override void SetStaticDefaults()
        {
			// Tooltip.SetDefault("Direct hits inflict fire debuff");
        }
        //Stats
        public override void SetDefaults()
		{
			Item.damage = 20;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 45;
			Item.useAnimation = 45;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.sellPrice(gold: 7);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = false;
			Item.shoot = 10;
			Item.shootSpeed = 15f;
			Item.useAmmo = AmmoID.Rocket;
		}

        //Shooty Effects
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			type = ModContent.ProjectileType<Projectiles.FireCracklerBomb>();
		}

        //Position Fix
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(-20, 0);
		}

		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ModContent.ItemType<FireCrackler>());
			recipe.AddIngredient(ItemID.HellstoneBar, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

		}
	}
}