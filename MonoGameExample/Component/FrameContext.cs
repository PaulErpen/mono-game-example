using Microsoft.Xna.Framework;
using MonoGameExample.Rendering;
using MonoGameExample.Rendering.GraphicsDeviceWrapper;
using MonoGameExample.Scene;

namespace MonoGameExample.Component
{
    public class FrameContext
    {
        public GameTime GameTime { get; }
        public Camera Camera { get; }
        public IGraphicsDeviceWrapper GraphicsDeviceWrapper { get; }
        public GameObject GameObject { get; }

        public FrameContext(GameTime gameTime, Camera camera, IGraphicsDeviceWrapper graphicsDevice, GameObject gameObject)
        {
            GameTime = gameTime;
            Camera = camera;
            GraphicsDeviceWrapper = graphicsDevice;
            GameObject = gameObject;
        }
    }
}
