namespace New_AWS_Project;

public class Enemy
{
    private int health;
    public int dmg;
    private Texture2D sprite;
    private Vector2 position;
    private int moveSpeed = 2;
    public int cooldown = 60;


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
        
    }

    public void Draw()
    {
        Globals._spriteBatch.Draw(sprite, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
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
}