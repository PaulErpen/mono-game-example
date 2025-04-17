using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameExample.Scene;

namespace MonoGameExample.Rendering
{
    public class Camera : SceneNode
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }
        public Transform Transform { get; set; }
        public Vector3 Target { get; private set; }
        public float AspectRatio { get; private set; }
        public float Fov { get; private set; }
        public float NearPlaneDistance { get; private set; }
        public float FarPlaneDistance { get; private set; }


        public Camera(string name, bool active)
            : this(name, active, 45f, 16f / 9f, 0.1f, 1000f)
        { }

        public Camera(string name, bool active, float fov, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            Active = active;
            Name = name;
            Fov = fov;
            AspectRatio = aspectRatio;
            NearPlaneDistance = nearPlaneDistance;
            FarPlaneDistance = farPlaneDistance;

            Transform = new Transform(null);

            Projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.ToRadians(Fov),
                AspectRatio,
                NearPlaneDistance,
                FarPlaneDistance);
        }

        public void UpdateViewProjection(Transform parent)
        {
            Transform.UpdateWorldMatrix(parent);

            Vector3 position = Transform.WorldMatrix.Translation;
            Vector3 forward = Vector3.Transform(Vector3.Forward, Transform.WorldMatrix);
            Vector3 up = Vector3.Transform(Vector3.Up, Transform.WorldMatrix);

            View = Matrix.CreateLookAt(position, position + forward, up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(Fov), AspectRatio, NearPlaneDistance, FarPlaneDistance);
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

        public void Initialize()
        {
            UpdateViewProjection(null);
        }

        public void UpdateWorldMatrix(Transform Parent)
        {
            UpdateViewProjection(Parent);
        }
    }
}

