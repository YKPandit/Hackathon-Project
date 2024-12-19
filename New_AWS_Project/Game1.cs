using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace New_AWS_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
	private Player player;
    private Item item;
    private Sword sword;

    //desired Game resolution
    private int _resolutionWidth = 640;
    private int _resolutionHeight = 360;
    
    //resolution we render at
    private int _virtualWidth = 640;
    private int _virtualHeight = 360;
    public Matrix _screenScaleMatrix;
    private Viewport _viewport;
    // Flags
    private bool _isResizing;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = _resolutionWidth;
		_graphics.PreferredBackBufferHeight = _resolutionHeight;
		_graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

		Window.AllowUserResizing = true;
        Window.ClientSizeChanged += OnClientSizeChanged;
    }
    private void OnClientSizeChanged(object sender, EventArgs e)
    {
        if (!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
        {
            _isResizing = true;
            UpdateScreenScaleMatrix();
            _isResizing = false;
        }
    }
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        player = new Player(this, new Vector2(100.0f,200.0f));
        item = new Item(this, new Vector2(200.0f,100.0f), "Fist", "Melee", "Common");
        sword = new Sword(this, new Vector2(400.0f,100.0f), "Sword", "Melee", "Common");
        UpdateScreenScaleMatrix();
        base.Initialize();
		
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        if (player.PositionRectangle.Intersects(item.ItemPositionRectangle) && !item.pickedUp)
        {
	        player.pickUp(item);
        }

        if (player.PositionRectangle.Intersects(sword.ItemPositionRectangle) && !sword.pickedUp)
        {
	        player.pickUp(sword);
        }
        
        base.Update(gameTime);
		player.Update(gameTime, _screenScaleMatrix);
    }
    

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GraphicsDevice.Viewport = _viewport;

		_spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: _screenScaleMatrix);
    	player.Draw(gameTime, _spriteBatch);
        item.Draw(gameTime, _spriteBatch);
        sword.Draw(gameTime, _spriteBatch);
    	_spriteBatch.End();
        // TODO: Add your drawing code here
        base.Draw(gameTime);
    }
    
    private void UpdateScreenScaleMatrix()
    {
        // Size of actual screen
        float screenWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
        float screenHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;

        // Calculate virtual resolution based on current screen width and height
        if (screenWidth/ _resolutionWidth > screenHeight / _resolutionHeight)
        {
            float aspect = screenHeight / _resolutionHeight;
            _virtualWidth = (int)(aspect * _resolutionWidth);
            _virtualHeight = (int)screenHeight;
        }
        else {
            float aspect = screenWidth / _resolutionWidth;
            _virtualWidth = (int)screenWidth;
            _virtualHeight = (int)(aspect * _resolutionHeight);
        }

        _screenScaleMatrix = Matrix.CreateScale(_virtualWidth / (float)_resolutionWidth, _virtualHeight / (float)_resolutionHeight, 1.0f);

        _viewport = new Viewport{
            X = (int)(screenWidth / 2 - _virtualWidth / 2),
            Y = (int)(screenHeight / 2 - _virtualHeight / 2),
            Width = _virtualWidth,
            Height = _virtualHeight,
            MinDepth = 0,
            MaxDepth = 1
        };
        
    }
}
