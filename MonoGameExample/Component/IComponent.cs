using Microsoft.Xna.Framework;

namespace MonoGameExample.Component
{
    public interface IComponent
    {
        void Initialize();
        void Update(GameTime gameTime);
    }
}