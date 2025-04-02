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

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = _worldMatrix;
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;
                }

                mesh.Draw();
            }
        }
    }
}