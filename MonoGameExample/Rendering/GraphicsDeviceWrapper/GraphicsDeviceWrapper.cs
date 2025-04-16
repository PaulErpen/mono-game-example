using System;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExample.Rendering.GraphicsDeviceWrapper
{
    public class GraphicsDeviceWrapper : IGraphicsDeviceWrapper
    {
        private readonly GraphicsDevice _graphicsDevice;

        public GraphicsDeviceWrapper(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice ?? throw new ArgumentNullException(nameof(graphicsDevice));
        }

        public GraphicsDevice GraphicsDevice => _graphicsDevice;
    }
}

