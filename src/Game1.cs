using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using mono_game_example.Rendering;
using mono_game_example.Rendering.Renderables;

namespace mono_game_example;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Model _model;
    private Renderer _renderer;
    private Camera _camera;
    private ModelRenderable _modelRenderable;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        _camera = new Camera(new Vector3(0, 0, 5), Vector3.Zero, Vector3.Up);
        _renderer = new Renderer(GraphicsDevice, _camera);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        _model = Content.Load<Model>("plane");
        _modelRenderable = new ModelRenderable(_model, Matrix.CreateTranslation(Vector3.Zero));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        // Draw the model
        _renderer.Render(_modelRenderable, gameTime);
        

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
