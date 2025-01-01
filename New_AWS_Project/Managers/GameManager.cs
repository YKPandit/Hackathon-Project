namespace New_AWS_Project;

public class GameManager{

	private Player player;

    public GameManager(){
        player = new Player(new Vector2(100.0f,200.0f));
        RoomManager.AddItem(new Item(new Vector2(200.0f,100.0f), "Fist", "Melee", "Common"));
        RoomManager.AddItem(new Bow(new Vector2(300.0f,100.0f), "Bow", "Ranged", "Common"));
        RoomManager.AddItem(new Sword(new Vector2(400.0f, 100.0f), "Sword", "Melee", "Common"));
        EnemyManager.AddEnemy("enemy", new Vector2(200.0f, 100.0f), 2, 5, 10, 60);
    }

    public void Update(){
        InputManager.Update();
        player.Update();
        RoomManager.Update(player);
        PlayerProjectileManager.Update(EnemyManager._enemies);
        EnemyManager.Update(player);
    }

    public void Draw(){
        player.Draw();
        RoomManager.Draw();
        PlayerProjectileManager.Draw();
        EnemyManager.Draw();
    }
}