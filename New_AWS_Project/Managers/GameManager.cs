namespace New_AWS_Project;

public class GameManager{

	private Player player;
    private Item item;
    private Sword sword;
    private Bow bow;

    public GameManager(){
        player = new Player(new Vector2(100.0f,200.0f));
        item = new Item(new Vector2(200.0f,100.0f), "Fist", "Melee", "Common");
        sword = new Sword(new Vector2(400.0f,100.0f), "Sword", "Melee", "Common");
        bow = new Bow(new Vector2(300.0f, 100.0f), "Bow", "Ranged", "Common");
        EnemyManager.AddEnemy("enemy", new Vector2(200.0f, 100.0f), 2, 5, 10, 60);
    }

    public void Update(){
        InputManager.Update();

        // FIX, MAKE IT NOT DOGSHIT
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
        
        
        player.Update();
        PlayerProjectileManager.Update(EnemyManager._enemies);
        EnemyManager.Update(player);
    }

    public void Draw(){
        player.Draw();
        item.Draw();
        sword.Draw();
        bow.Draw();
        PlayerProjectileManager.Draw();
        EnemyManager.Draw();
    }
}