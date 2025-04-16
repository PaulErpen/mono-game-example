using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGameExample.Scene;

namespace MonoGameExample.Component
{
    public class ExampleControlsComponent : IComponent
    {
        private GameObject _gameObject;
        private float _speed;

        public ExampleControlsComponent(GameObject gameObject, float speed)
        {
            _gameObject = gameObject;
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
                movement += Vector3.Forward;
            if (keyboardState.IsKeyDown(Keys.S))
                movement += Vector3.Backward;
            if (keyboardState.IsKeyDown(Keys.A))
                movement += Vector3.Left;
            if (keyboardState.IsKeyDown(Keys.D))
                movement += Vector3.Right;

            // Apply the movement to the game object's position
            _gameObject.Transform.Position += movement * speed;
        }
    }
}
