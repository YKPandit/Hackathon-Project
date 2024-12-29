namespace New_AWS_Project;

public class Enemy
{
    private int health;
    public int dmg;
    private Texture2D sprite;
    private Vector2 position;
    private int moveSpeed = 2;
    public int cooldown = 60;
    public bool dead = false;

    
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }
    }

    public Enemy(Vector2 pos)
    {
        position = pos;
        health = 5;
        dmg = 10;
        LoadContent();
    }
    
    
    public void LoadContent()
    {
        sprite = Globals.Content.Load<Texture2D>("enemy");
    }

    public void Update()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }

    public void Draw()
    {
        if (!dead)
        {
            Globals._spriteBatch.Draw(sprite, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }

    public Vector2 getPosition()
    {
        return position;
    }

    public void move(Vector2 playerPos)
    {
        position.X += moveSpeed*((playerPos.X - position.X)/60);
        position.Y += moveSpeed*((playerPos.Y - position.Y)/60);
    }
    
    public void enemyDamage(int damage)
    {
        health -= damage;
    }
}