using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExample.Rendering;
using MonoGameExample.Scene;

namespace MonoGameExample.Component
{
    public class FrameContext {
        public GameTime GameTime { get; }
        public Camera Camera { get; }
        public GraphicsDevice GraphicsDevice { get; }
        public GameObject GameObject { get; }

        public FrameContext(GameTime gameTime, Camera camera, GraphicsDevice graphicsDevice, GameObject gameObject)
        {
            GameTime = gameTime;
            Camera = camera;
            GraphicsDevice = graphicsDevice;
            GameObject = gameObject;
        }
    }
}