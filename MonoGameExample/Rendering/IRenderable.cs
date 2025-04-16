using Microsoft.Xna.Framework;

namespace MonoGameExample.Rendering
{
    public interface IRenderable
    {
        void Draw(GameTime gameTime, Camera camera);
    }
}
