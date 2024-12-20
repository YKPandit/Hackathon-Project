namespace New_AWS_Project;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private GameManager GameManager;

    //desired Game resolution
    private int _resolutionWidth = 640;
    private int _resolutionHeight = 360;
    
    //resolution we render at
    private int _virtualWidth = 640;
    private int _virtualHeight = 360;
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

        Globals.game1 = this;
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
        Globals.Content = Content;
        GameManager = new GameManager();
        UpdateScreenScaleMatrix();
        base.Initialize();
		
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals._spriteBatch = _spriteBatch;
        // TODO: use this.Content to load your game content here


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Globals.Update(gameTime);
        GameManager.Update(gameTime);
        
        base.Update(gameTime);

    }
    

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GraphicsDevice.Viewport = _viewport;

		Globals._spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Globals._screenScaleMatrix);
        GameManager.Draw(gameTime);
    	Globals._spriteBatch.End();
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

        Globals._screenScaleMatrix = Matrix.CreateScale(_virtualWidth / (float)_resolutionWidth, _virtualHeight / (float)_resolutionHeight, 1.0f);

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
