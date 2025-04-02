using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mono_game_example.Rendering
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

        public void Render(IRenderable renderable, GameTime gameTime)
        {
            if (renderable == null) throw new ArgumentNullException(nameof(renderable));

            _graphicsDevice.Clear(Color.CornflowerBlue);
            renderable.Draw(gameTime, _camera);
        }
    }
}