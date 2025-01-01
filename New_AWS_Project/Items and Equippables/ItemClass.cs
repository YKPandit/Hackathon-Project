// Adapter class that stores general info about item
// I.e name, description, value, rarity, weight, etc
// Also includes methods for attack, use, etc.

namespace New_AWS_Project;

public class Item
{
    protected Texture2D ItemSprite { get; set; } // Sprite for item
    protected Vector2 ItemPosition { get; set; } // Position of item on screen
    protected Vector2 ItemOrigin { get; set; } // Position to rotate
    public Rectangle ItemPositionRectangle;
    public float rotation { get; set; } // Rotation of item
    public string Name { get; set; }
    public string Type { get; set; }
    public string Rarity { get; set; }
    public float opacity = 1.0f;
    public bool pickedUp = false;
    protected int damage = 1;
    protected float cooldown;
    protected float cooldownLeft = 0;

    public SpriteEffects spriteEffect = SpriteEffects.None;

    public Item(Vector2 position, string name, string type, string rarity)
    {
        ItemPosition = position;
        LoadContent();
        Name = name;
        Type = type;
        Rarity = rarity;
        cooldown = 0.5f;
    }

    public Texture2D getTexture()
    {
        return ItemSprite;
    }
    public void UpdateItemPositionRectangle() // Create hitbox for item
    {
        Matrix transformationMatrix = Matrix.CreateTranslation(new Vector3(-ItemOrigin, 0)) *
                                       Matrix.CreateRotationZ(rotation) *
                                       Matrix.CreateTranslation(new Vector3(ItemPosition, 0));
        Vector2 topLeft = Vector2.Transform(Vector2.Zero, transformationMatrix);
        Vector2 topRight = Vector2.Transform(new Vector2(ItemSprite.Width, 0), transformationMatrix);
        Vector2 bottomLeft = Vector2.Transform(new Vector2(0, ItemSprite.Height), transformationMatrix);
        Vector2 bottomRight = Vector2.Transform(new Vector2(ItemSprite.Width, ItemSprite.Height), transformationMatrix);

        Vector2 min = new Vector2(Math.Min(Math.Min(topLeft.X, topRight.X), Math.Min(bottomLeft.X, bottomRight.X)), 
                                Math.Min(Math.Min(topLeft.Y, topRight.Y), Math.Min(bottomLeft.Y, bottomRight.Y)));

        Vector2 max = new Vector2(Math.Max(Math.Max(topLeft.X, topRight.X), Math.Max(bottomLeft.X, bottomRight.X)), 
                                Math.Max(Math.Max(topLeft.Y, topRight.Y), Math.Max(bottomLeft.Y, bottomRight.Y)));     

        ItemPositionRectangle = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));                    

        
    }
    public virtual void LoadContent(){ // Load item sprite and postition at characters hand area 
        // Default sprite load for item is fist
        ItemSprite = Globals.Content.Load<Texture2D>("Fist");
    }

    public void Draw()
    {
        
        Globals._spriteBatch.Draw(
            ItemSprite,
            ItemPosition,
            null,
            Color.White * opacity,
            rotation,
            ItemOrigin,
            1f,
            spriteEffect,
            0f
        );
    }

    public virtual void Use(Player player)
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

    public void setPosition(Vector2 newPos)
    {
        ItemPosition = newPos;
		opacity = 1.0f;

    }
    public void pickedUpItem()
    {
        opacity *= 0.0f;
        pickedUp = true;
    }

    public void setInvis()
    {
        opacity = 0.0f;
    }

    public void mousePosition(){
        Vector2 dPos = ItemPosition - InputManager.MousePosition;
        rotation = (float)Math.Atan2(dPos.Y, dPos.X);
        
        if(ItemPosition.X + ItemSprite.Width/2 < InputManager.MousePosition.X)
        {
            spriteEffect = SpriteEffects.None;
        }
        else if(ItemPosition.X + ItemSprite.Width/2 > InputManager.MousePosition.X)
        {
            spriteEffect = SpriteEffects.FlipVertically;
        }
    }

    public void reduceCooldown(){
        if (cooldownLeft > 0)
        {
            cooldownLeft -= Globals.totalSeconds;
        }
    }

    public void Update(Player player){
		ItemPosition = player.getCenter();
        ItemOrigin = new Vector2(ItemSprite.Width, ItemSprite.Height / 2f);
        mousePosition();
        UpdateItemPositionRectangle();

        foreach (Enemy enemy in EnemyManager._enemies)
        {
            if (ItemPositionRectangle.Intersects(enemy.PositionRectangle))
            {
                Console.WriteLine("Enemy hit");
            }
        }
        
        if (InputManager.LeftDown){
            Use(player);
        }
	}
}

