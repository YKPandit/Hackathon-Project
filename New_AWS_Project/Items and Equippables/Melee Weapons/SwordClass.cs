// Specific class to handle the sword weapon, child of Item

using New_AWS_Project;

public class Sword : Item
{
    // Constructor
    public Sword(Vector2 position, string name, string type, string rarity)
    : base(position, name, type, rarity)
    {
        LoadContent();
        damage = 10;
    }

    public override void LoadContent(){ 
        // Load sword sprite
        base.ItemSprite = Globals.Content.Load<Texture2D>("3bbc0d500f6805b6e086d8f51ccd1870(1)");
    }

    public override void Use(Player player)
    {
        if (cooldownLeft > 0) return;
        
        cooldownLeft = cooldown;
        player.inventory.attacking = true;


        List<Enemy> hitList = new List<Enemy>();
        /* Create a list of enemies that have been hit, will be used for when animations are added
        This will allow the enemy to be hit only once per animation, instead of every frame
        */
        foreach (Enemy enemy in EnemyManager._enemies)
        {
            if (ItemPositionRectangle.Intersects(enemy.PositionRectangle) && !hitList.Contains(enemy))
            {
                enemy.enemyDamage(damage);
                hitList.Add(enemy);
            }
        }
        player.inventory.attacking = false;

    }

}

