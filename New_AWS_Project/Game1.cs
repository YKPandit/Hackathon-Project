using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace New_AWS_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
	private Player player;
    private Item item;
    private Texture2D p;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
		Window.AllowUserResizing = true;
		Window.ClientSizeChanged += Window_ClientSizeChanged;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
		_graphics.PreferredBackBufferWidth = 800;  // Or your desired width
		_graphics.PreferredBackBufferHeight = 600; // Or your desired height
		_graphics.ApplyChanges();
		_graphics.PreferMultiSampling = true;
		Window.AllowUserResizing = true;
        base.Initialize();
		player = new Player(this, new Vector2(100.0f,200.0f));
		
    }

	protected void Window_ClientSizeChanged(object sender, EventArgs e)
	{
    	int width = Window.ClientBounds.Width;
    	int height = Window.ClientBounds.Height;
    
    	_graphics.PreferredBackBufferWidth = width;
    	_graphics.PreferredBackBufferHeight = height;
    	_graphics.ApplyChanges();
	}



    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here

        p = Content.Load<Texture2D>("priest1_v1_1");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
		player.Update(gameTime);
    }
    
    

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
		_spriteBatch.Begin();
    	player.Draw(gameTime, _spriteBatch);
    	_spriteBatch.End();
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
}
