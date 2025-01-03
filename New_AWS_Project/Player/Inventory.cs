// Player Inventory System

namespace New_AWS_Project;

public class Inventory
{
	public Item[] inventory = new Item[4];
	public int currentSlot = 0;
	private Texture2D inventorySprite = Globals.Content.Load<Texture2D>("Sample-InventorySlotsSet_Single");
	private Vector2 inventoryPosition;
	public bool inventoryFull = false;
	public bool attacking = false; // used to lock inventory while attacking
    
    private void inventorySelect(Vector2 playerCenter){
		if (attacking) return; // if player is attacking, do not allow inventory selection/dropping

		if (!InputManager._previousKeyboardState.IsKeyDown(Keys.E) && InputManager._currentKeyboardState.IsKeyDown(Keys.E) && inventory[currentSlot] != null)
		{
			Drop(playerCenter);
		}

        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D1))
        {
	        int oldSlot = currentSlot == 0? -1 : currentSlot;
	        currentSlot = 0;

	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }

        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D2))
        {

	        int oldSlot = currentSlot != 1? currentSlot:-1;
	        currentSlot = 1;

	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D3))
        {

	        int oldSlot = currentSlot != 2? currentSlot:-1;
	        currentSlot = 2;

	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (InputManager._currentKeyboardState.IsKeyDown(Keys.D4))
        {

	        int oldSlot = currentSlot != 3? currentSlot:-1;
	        currentSlot = 3;

	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }

        }
	}

    public void Drop(Vector2 playerCenter)
    {

	    Item droppedItem = inventory[currentSlot];
	    inventory[currentSlot] = null;

		inventoryFull = false;
		
		droppedItem.setPosition(playerCenter);
	    droppedItem.pickedUp = false;
		RoomManager._items.Add(droppedItem);
    }


    public void Draw(){
        Globals._spriteBatch.Draw(inventorySprite, inventoryPosition, Color.White);
        if (inventory[currentSlot] != null)
        {
	        inventory[currentSlot].Draw();
        }

        for (int i = 0; i < inventory.Length; i++)
        {
	        if (inventory[i] != null)
	        {
		        Globals._spriteBatch.Draw(inventory[i].getTexture(), new Vector2(inventoryPosition.X + 25 * i, inventoryPosition.Y + 5), Color.White);
	        }
        }
    }
    public void Update(Player player){

		if(inventoryPosition.X == 0)
		{
			inventoryPosition = new Vector2(Globals._screenSize.X - 75, Globals._screenSize.Y - 29);
		}
		Vector2 playerCenter = player.getCenter();
        inventorySelect(playerCenter);
		inventory[currentSlot]?.Update(player);

        for (int i = 0; i < inventory.Length; i++)
        {
	        if (inventory[i] != null)
	        {
		        inventory[i].reduceCooldown();
	        }
        }


    }
}