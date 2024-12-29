namespace New_AWS_Project;

public class GameManager{

	private Player player;
    private Item item;
    private Sword sword;
    private Bow bow;
    private Enemy enemy;

    public GameManager(){
        player = new Player(new Vector2(100.0f,200.0f));
        item = new Item(new Vector2(200.0f,100.0f), "Fist", "Melee", "Common");
        sword = new Sword(new Vector2(400.0f,100.0f), "Sword", "Melee", "Common");
        bow = new Bow(new Vector2(300.0f, 100.0f), "Bow", "Ranged", "Common");
        enemy = new Enemy(new Vector2(200.0f, 100.0f));
    }

    public void Update(){
        InputManager.Update();
        if (player.PositionRectangle.Intersects(item.ItemPositionRectangle) && !item.pickedUp)
        {
	        player.pickUp(item);
        }

        if (player.PositionRectangle.Intersects(sword.ItemPositionRectangle) && !sword.pickedUp)
        {
	        player.pickUp(sword);
        }

        if (player.PositionRectangle.Intersects(bow.ItemPositionRectangle) && !bow.pickedUp)
        {
	        player.pickUp(bow);
        }
        
        Vector2 playerPos = player.getPosition();
        if (!enemy.dead && Vector2.Distance(playerPos, enemy.getPosition()) <= 100)
        {
            enemy.move(playerPos);
            if (Vector2.Distance(playerPos, enemy.getPosition()) <= 25 && enemy.cooldown >= 60)
            {
                player.playerDamage(enemy.dmg);
                enemy.cooldown = 0;
            }
            else
            {
                enemy.cooldown++;
            }
        }
        
        
        player.Update();
        PlayerProjectileManager.Update(enemy);
        enemy.Update();
    }

    public void Draw(){
        player.Draw();
        item.Draw();
        sword.Draw();
        bow.Draw();
        PlayerProjectileManager.Draw();
        enemy.Draw();
    }

}