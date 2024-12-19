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
	private KeyboardState previousState = Keyboard.GetState();
	

   
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
    
    public void Update(GameTime gameTime, Matrix transformMatrix)
    {
		KeyboardState currentKeyboardState = Keyboard.GetState();
		mousePosition(Matrix.Invert(transformMatrix));
    	playerMovement(currentKeyboardState);
		Inventory(currentKeyboardState);

	    if (inventory[currentSlot] != null)
	    { 
		    inventory[currentSlot].Update(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
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
		if (currentKey.IsKeyDown(Keys.E) && !previousState.IsKeyDown(Keys.E))
		{
			drop();
		}
		previousState = currentKey;

        if (currentKey.IsKeyDown(Keys.D1))
        {
	        int oldSlot = currentSlot == 0? -1 : currentSlot;
	        currentSlot = 0;
	        if (inventory[currentSlot] != null)
	        {
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
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
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
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
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
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
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
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
		        inventory[currentSlot].setPosition(playerPosition + new Vector2(playerTexture.Width/2f, playerTexture.Height/2f));
	        }
	        if (oldSlot != -1 && inventory[oldSlot] != null)
	        {
		        inventory[oldSlot].pickedUpItem();
	        }
        }
	}

    private void mousePosition(Matrix transformMatrix)
    {
        Vector2 currentMousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
		Vector2 globalMousePosition = Vector2.Transform(currentMousePosition, transformMatrix);

        // The mouse x and y positions are returned relative to the
        // upper-left corner of the game window
        if(playerPosition.X + playerTexture.Width/2f < globalMousePosition.X)
		{
			spriteEffect = SpriteEffects.None;
		}
		else if(playerPosition.X + playerTexture.Width/2f > globalMousePosition.X)
		{
			spriteEffect = SpriteEffects.FlipHorizontally;
		}

		inventory[currentSlot]?.mousePosition(globalMousePosition);
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

    public void drop()
    {
	    Item droppedItem = inventory[currentSlot];
	    inventory[currentSlot] = null;
	    
	    
	    if (currentSlot < 5 && inventory[currentSlot + 1] != null)
	    {
		    currentSlot += 1;
	    }
	    else if (currentSlot > 0 && inventory[currentSlot - 1] != null)
	    {
		    currentSlot -= 1;
			lastSlot--;
	    }
	    else
	    {
		    currentSlot = 0;
			lastSlot--;
	    }
		
		droppedItem.setPosition(new Vector2(playerPosition.X + 100, playerPosition.Y));
	    droppedItem.pickedUp = false;
    }
}