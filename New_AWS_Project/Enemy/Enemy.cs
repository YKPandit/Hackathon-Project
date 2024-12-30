// Parent class for all enemies

namespace New_AWS_Project;

public class Enemy
{
    public int health;
    public int dmg;
    public Texture2D enemySprite;
    public Vector2 position;
    public int moveSpeed;
    protected float attackCooldown;
    protected float attackTimer = 0f;

    public Enemy(Vector2 pos, int health, int dmg, string sprite, int speed, float cooldown)
    {
        position = pos;
        this.health = health;
        this.dmg = dmg;
        moveSpeed = speed;
        attackCooldown = cooldown;
        LoadContent(sprite);
    }

    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, enemySprite.Width, enemySprite.Height);
        }
    }
    
    
    public virtual void LoadContent(string sprite)
    {
        enemySprite = Globals.Content.Load<Texture2D>(sprite);
    }

    public virtual void Draw()
    {
        Globals._spriteBatch.Draw(enemySprite, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    }

    public virtual void move(Vector2 playerPos)
    {
        position.X += moveSpeed*((playerPos.X - position.X)/60);
        position.Y += moveSpeed*((playerPos.Y - position.Y)/60);
    }
    
    public void enemyDamage(int damage)
    {
        health -= damage;
    }

    public virtual void Attack(Player player)
    {
        attackTimer = attackCooldown;
        player.playerDamage(dmg);

    }

    public void Update(Player player)
    {
        move(player.getPosition());

        if (attackTimer > 0)
        {
            attackTimer -= Globals.totalSeconds;
        }

        if (attackTimer <= 0 && PositionRectangle.Intersects(player.PositionRectangle))
        {
            Attack(player);
        }
    }
}