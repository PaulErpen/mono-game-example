using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExample.Rendering;
using MonoGameExample.Rendering.Renderables;
using MonoGameExample.Scene;

namespace MonoGameExample;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Model _model;
    private Renderer _renderer;
    private Camera _camera;
    private ModelRenderable _modelRenderable;
    private GameObject _rootGameObject;
    private GameObject _planeObject = new GameObject("Plane");

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
        _camera = new Camera(new Vector3(0, 0, 80), Vector3.Zero, Vector3.Up);
        _renderer = new Renderer(GraphicsDevice, _camera);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _rootGameObject = new GameObject("Root");

        // TODO: use this.Content to load your game content here
        _model = Content.Load<Model>("plane");
        _modelRenderable = new ModelRenderable(_model, _planeObject);

        _rootGameObject.AddChild(_planeObject);
        _planeObject.Transform.Rotation = Quaternion.CreateFromAxisAngle(Vector3.Left, MathHelper.ToRadians(90)) * Quaternion.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(90));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Get the keyboard state
        KeyboardState keyboardState = Keyboard.GetState();

        // Movement speed
        float speed = 20f * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Update plane position based on WASD input
        Vector3 movement = Vector3.Zero;

        if (keyboardState.IsKeyDown(Keys.W))
            movement.Y += speed; // Move up
        if (keyboardState.IsKeyDown(Keys.S))
            movement.Y -= speed; // Move down
        if (keyboardState.IsKeyDown(Keys.A))
            movement.X -= speed; // Move left
        if (keyboardState.IsKeyDown(Keys.D))
            movement.X += speed; // Move right


        Vector3 extent = _camera.ScreenToWorld(
            new Vector2(0, 0),
            80,
            GraphicsDevice);

        _planeObject.Transform.Position = new Vector3(
            MathHelper.Clamp(_planeObject.Transform.Position.X + movement.X, extent.X, -extent.X),
            MathHelper.Clamp(_planeObject.Transform.Position.Y + movement.Y, -extent.Y, extent.Y),
            _planeObject.Transform.Position.Z
        );

        // TODO: Add your update logic here
        _rootGameObject.UpdateWorldMatrix(null);

        base.Update(gameTime);
    }



    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        // Draw the model
        _renderer.Clear(Color.CornflowerBlue);
        _renderer.Render(_modelRenderable, gameTime);


        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
