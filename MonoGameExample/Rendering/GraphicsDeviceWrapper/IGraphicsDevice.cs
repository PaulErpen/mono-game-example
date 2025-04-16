using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExample.Rendering.GraphicsDeviceWrapper
{
    public interface IGraphicsDeviceWrapper
    {
        GraphicsDevice GraphicsDevice { get; }
    }
}