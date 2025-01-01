// Specific class to handle the bow weapon
namespace New_AWS_Project;
public class Bow : Item{
    public Bow(Vector2 position, string name, string type, string rarity)
    : base(position, name, type, rarity){
        LoadContent();
        cooldown = 1.0f;
        damage = 5;
    }

    public override void LoadContent(){ 
        // Load sword sprite
        base.ItemSprite = Globals.Content.Load<Texture2D>("Bow");
    }

    public override void Use(Player player)
    {
        if (cooldownLeft > 0) return;
        
        cooldownLeft = cooldown;
        player.inventory.attacking = true;

        // Create a new projectile
        PlayerProjectileManager.AddProjectile("Arrow", new Vector2(ItemPosition.X, ItemPosition.Y), 600, rotation, 2, damage);
        player.inventory.attacking = false;

    }
}