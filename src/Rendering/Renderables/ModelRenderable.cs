using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace mono_game_example.Rendering.Renderables
{
    public class ModelRenderable : IRenderable
    {
        private readonly Model _model;
        private readonly Matrix _worldMatrix;

        public ModelRenderable(Model model, Matrix worldMatrix)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _worldMatrix = worldMatrix;
        }
        public void Draw(GameTime gameTime, Camera camera)
        {
            if (camera == null) throw new ArgumentNullException(nameof(camera));

            foreach (var mesh in _model.Meshes)
            {
                foreach (var effect in mesh.Effects)
                {
                    effect.Parameters["World"].SetValue(_worldMatrix);
                    effect.Parameters["View"].SetValue(camera.View);
                    effect.Parameters["Projection"].SetValue(camera.Projection);
                }

                mesh.Draw();
            }
        }
    }
}