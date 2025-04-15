using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExample.Scene;

namespace MonoGameExample.Rendering.Renderables
{
    public class ModelRenderable : IRenderable
    {
        private readonly Model _model;
        private readonly GameObject _gameObject;

        public ModelRenderable(Model model, GameObject gameObject)
        {
            _model = model ?? throw new ArgumentNullException(nameof(model));
            _gameObject = gameObject;
        }
        public void Draw(GameTime gameTime, Camera camera)
        {
            if (camera == null) throw new ArgumentNullException(nameof(camera));

            foreach (ModelMesh mesh in _model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = _gameObject.Transform.WorldMatrix;
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;
                }

                mesh.Draw();
            }
        }
    }
}