using Microsoft.Xna.Framework;

namespace mono_game_example.Scene
{
    public class Transform
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Quaternion Rotation { get; set; } = Quaternion.Identity;
        public Vector3 Scale { get; set; } = Vector3.One;

        public Transform Parent { get; set; } // Parent node
        public Matrix WorldMatrix { get; private set; }

        public Transform()
        {
            UpdateWorldMatrix();
        }

        public void UpdateWorldMatrix()
        {
            // Create Local Transformation Matrix
            Matrix localMatrix =
                Matrix.CreateScale(Scale) *
                Matrix.CreateFromQuaternion(Rotation) *
                Matrix.CreateTranslation(Position);

            // If parent exists, combine parent world transform
            if (Parent != null)
            {
                WorldMatrix = localMatrix * Parent.WorldMatrix;
            }
            else
            {
                WorldMatrix = localMatrix;
            }
        }
    }
}