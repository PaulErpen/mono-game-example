using Microsoft.Xna.Framework;

namespace MonoGameExample.Scene
{
    public class Transform
    {
        public Vector3 Position { get; set; } = Vector3.Zero;
        public Quaternion Rotation { get; set; } = Quaternion.Identity;
        public Vector3 Scale { get; set; } = Vector3.One;

        public Matrix WorldMatrix { get; private set; }

        public Transform(Transform Parent)
        {
            UpdateWorldMatrix(Parent);
        }

        public void UpdateWorldMatrix(Transform Parent)
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