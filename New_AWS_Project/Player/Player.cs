namespace New_AWS_Project;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


public class Player
{
    private Game1 player;
    private Texture2D playerTexture;
    private Vector2 playerPosition;
	private float moveSpeed = 4.0f;
	private Item[] inventory = new Item[5];
	private int lastSlot = 0;
	private int currentSlot = 0;
	private SpriteEffects spriteEffect = SpriteEffects.None;
	

   
    public Rectangle PositionRectangle
    {
        get
        {
            return new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerTexture.Width, playerTexture.Height);
        }
    }
    public Player(Game1 player, Vector2 position)
    {
        this.player = player;
        this.playerPosition = position;

        LoadContent();
    }
    

	// Generation of player
    public void LoadContent()
    {
        playerTexture = player.Content.Load<Texture2D>("priest1_v1_1");
    }
    
    public void Update(GameTime gameTime)
    {
		KeyboardState currentKeyboardState = Keyboard.GetState();
		mousePosition();
    	playerMovement(currentKeyboardState);
		Inventory(currentKeyboardState);

	    if (inventory[currentSlot] != null)
	    { 
		    inventory[currentSlot].Update(playerPosition);
	    }
    }

	public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(playerTexture, playerPosition, null, Color.White, 0f, Vector2.Zero, 1f, spriteEffect, 0f);
    }
	
    
	// Player Movement
	private void playerMovement(KeyboardState currentKey)
	{
		// Movement checking
		if (currentKey.IsKeyDown(Keys.W))
        {
            playerPosition.Y -= moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.S))
        {
            playerPosition.Y += moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.A))
        {
            playerPosition.X -= moveSpeed;
        }
        if (currentKey.IsKeyDown(Keys.D))
        {
            playerPosition.X += moveSpeed;
        }
		
	}
	
	private void Inventory(KeyboardState currentKey){
		int dropped = 0;
		if (currentKey.IsKeyDown(Keys.E))
		{
			if(dropped == 0)
			{
				drop();
			}
			dropped++;
		}
        if (currentKey.IsKeyDown(Keys.D1))
        {
	        int oldSlot = currentSlot == 0? -1 : currentSlot;
	        currentSlot = 0;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition);
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (currentKey.IsKeyDown(Keys.D2))
        {
	        int oldSlot = currentSlot != 1? currentSlot:-1;
	        currentSlot = 1;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition);
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (currentKey.IsKeyDown(Keys.D3))
        {
	        int oldSlot = currentSlot != 2? currentSlot:-1;
	        currentSlot = 2;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition);
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (currentKey.IsKeyDown(Keys.D4))
        {
	        int oldSlot = currentSlot != 3? currentSlot:-1;
	        currentSlot = 3;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition);
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
        if (currentKey.IsKeyDown(Keys.D5))
        {
	        int oldSlot = currentSlot != 4? currentSlot:-1;
	        currentSlot = 4;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition);
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
	}

    private void mousePosition()
    {
        MouseState current_mouse = Mouse.GetState();

        // The mouse x and y positions are returned relative to the
        // upper-left corner of the game window.

        if(playerPosition.X + playerTexture.Width/2 < current_mouse.X)
		{
			spriteEffect = SpriteEffects.None;
		}
		else if(playerPosition.X + playerTexture.Width/2 > current_mouse.X)
		{
			spriteEffect = SpriteEffects.FlipHorizontally;
		}
    }

    public void pickUp(Item item)
    {
	    if (lastSlot < 5)
	    {
		    inventory[lastSlot] = item;
		    item.pickedUpItem();
		    lastSlot++;
	    }
    }

    private int counter = 0;
    public void drop()
    {
	    
	    Console.WriteLine("Counter:" + counter);
	    counter++;
	    Console.WriteLine(inventory[currentSlot].Name);
	    
	    
	    Item droppedItem = inventory[currentSlot];
	    inventory[currentSlot] = null;
	    
	    
	    if (currentSlot < 5 && inventory[currentSlot + 1] != null)
	    {
		    currentSlot += 1;
	    }
	    else if (currentSlot > 0 && inventory[currentSlot - 1] != null)
	    {
		    currentSlot -= 1;
	    }
	    else
	    {
		    currentSlot = 0;
	    }

	    droppedItem.pickedUp = false;
    }
}