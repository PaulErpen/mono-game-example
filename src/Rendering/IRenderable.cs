using Microsoft.Xna.Framework;

namespace mono_game_example.Rendering
{
    public interface IRenderable
    {
        void Draw(GameTime gameTime, Camera camera);
    }
}