using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExample.Rendering
{
    public class Camera
    {
        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 Target { get; private set; }
        public Vector3 Up { get; private set; }
        public float Fov { get; private set; } = 45f;

        public Camera(Vector3 position, Vector3 target, Vector3 up)
        {
            Position = position;
            Target = target;
            Up = up;

            View = Matrix.CreateLookAt(Position, Target, Up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(Fov), 1.33f, 0.1f, 100f);
        }

        public Vector3 ScreenToWorld(Vector2 screenPosition, float worldDepth, GraphicsDevice graphicsDevice)
        {
            // var worldDepthScaled = (float)(worldDepth * Math.Sin(MathHelper.ToRadians(90)) / Math.Sin(MathHelper.ToRadians(180 - Fov / 2f - 90)));

            // Get the viewport from the graphics device
            Viewport viewport = graphicsDevice.Viewport;

            // Convert screen position to a 3D vector with a depth value
            Vector3 screenSpaceNear = new Vector3(screenPosition, 0f); // Near plane (Z = 0)
            Vector3 screenSpaceFar = new Vector3(screenPosition, 1f);  // Far plane (Z = 1)

            // Unproject screen coordinates into world space
            Vector3 worldNear = viewport.Unproject(screenSpaceNear, Projection, View, Matrix.Identity);
            Vector3 worldFar = viewport.Unproject(screenSpaceFar, Projection, View, Matrix.Identity);

            // Compute a world space point at the given depth along the ray
            Vector3 direction = Vector3.Normalize(worldFar - worldNear);
            var scale = float.Abs(1 / direction.Z);
            return worldNear + direction * worldDepth * scale;
        }
    }
}

