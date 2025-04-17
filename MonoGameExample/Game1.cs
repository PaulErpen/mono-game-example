using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameExample.Component;
using MonoGameExample.Rendering;
using MonoGameExample.Rendering.GraphicsDeviceWrapper;
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
        _camera = new Camera("Camera", true);
        _camera.Transform.Position = new Vector3(0, 0, 80);
        _rootGameObject.AddChild(_camera);

        _renderer = new Renderer(GraphicsDevice, _camera);

        _planeObject.Components.Add(new ExampleControlsComponent(10f));
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


        // TODO: Add your update logic here
        _rootGameObject.Update(gameTime, _camera, new GraphicsDeviceWrapper(GraphicsDevice));
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
