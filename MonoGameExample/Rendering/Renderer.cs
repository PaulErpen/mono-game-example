using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExample.Rendering
{
    public class Renderer
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly Camera _camera;

        public Renderer(GraphicsDevice graphicsDevice, Camera camera)
        {
            _graphicsDevice = graphicsDevice ?? throw new ArgumentNullException(nameof(graphicsDevice));
            _camera = camera ?? throw new ArgumentNullException(nameof(camera));
        }

        public void Clear(Color color)
        {
            _graphicsDevice.Clear(color);
        }

        public void Render(IRenderable renderable, GameTime gameTime)
        {
            if (renderable == null) throw new ArgumentNullException(nameof(renderable));

            renderable.Draw(gameTime, _camera);
        }
    }
}