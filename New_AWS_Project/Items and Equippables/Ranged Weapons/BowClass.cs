// Specific class to handle the bow weapon
namespace New_AWS_Project;
public class Bow : Item{
    public Bow(Vector2 position, string name, string type, string rarity)
    : base(position, name, type, rarity){LoadContent();}

    public override void LoadContent(){ 
        // Load sword sprite
        base.ItemSprite = Globals.Content.Load<Texture2D>("Bow");
    }

    public override void Attack()
    {
        // Attack with bow, creates projectile
    }
}