using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoGameExample.Component
{
    public class ExampleControlsComponent : IComponent
    {
        private float _speed;

        public ExampleControlsComponent(float speed)
        {
            _speed = speed;
        }

        public void Initialize()
        {
            // Initialization logic if needed
        }

        public void Update(FrameContext frameContext)
        {
            // Get the keyboard state
            KeyboardState keyboardState = Keyboard.GetState();

            // Movement speed
            float speed = _speed * (float)frameContext.GameTime.ElapsedGameTime.TotalSeconds;

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

            Vector3 extent = frameContext.Camera.ScreenToWorld(
                new Vector2(0, 0),
                frameContext.GameObject.Transform.Position.Z * -1,
                frameContext.GraphicsDeviceWrapper.GraphicsDevice);

            frameContext.GameObject.Transform.Position = new Vector3(
                MathHelper.Clamp(frameContext.GameObject.Transform.Position.X + movement.X, extent.X, -extent.X),
                MathHelper.Clamp(frameContext.GameObject.Transform.Position.Y + movement.Y, -extent.Y, extent.Y),
                frameContext.GameObject.Transform.Position.Z
            );
        }
    }
}
