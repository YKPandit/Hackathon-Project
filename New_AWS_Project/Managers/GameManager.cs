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
    }

    public void Update(GameTime gameTime){
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
        player.Update(gameTime);
    }

    public void Draw(GameTime gameTime){
        player.Draw(gameTime);
        item.Draw(gameTime);
        sword.Draw(gameTime);
        bow.Draw(gameTime);
    }

}