using Microsoft.Xna.Framework;
using MonoGameExample.Rendering;
using MonoGameExample.Scene;
using Xunit;

namespace MonoGameExample.Tests.Rendering
{


    public class CameraTests
    {
        [Fact]
        public void TestCameraInitialization()
        {
            // Arrange
            var camera = new Camera("Camera", true);

            // Act
            var name = camera.Name;

            // Assert
            Assert.Equal("Camera", name);
        }

        [Fact]
        public void TestCameraUpdateViewProjection()
        {
            // Arrange
            var camera = new Camera("Camera", true);
            var parentTransform = new Transform(null);
            parentTransform.Position = new Vector3(0, 0, 0);
            parentTransform.Rotation = Quaternion.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(45));
            parentTransform.Scale = Vector3.One;

            // Act
            parentTransform.UpdateWorldMatrix(null);
            camera.UpdateViewProjection(parentTransform);

            // Assert
            Assert.NotEqual(Matrix.Identity, camera.View);
            Assert.NotEqual(Matrix.Identity, camera.Projection);
        }

        [Fact]
        public void TestCameraUpdateViewProjectionTranslation()
        {
            // Arrange
            var camera = new Camera("Camera", true);
            var parentTransform = new Transform(null);
            parentTransform.Position = new Vector3(0, 3, 0);
            parentTransform.Rotation = Quaternion.Identity;
            parentTransform.Scale = Vector3.One;

            // Act
            parentTransform.UpdateWorldMatrix(null);
            camera.UpdateViewProjection(parentTransform);

            // Assert
            Assert.Equal(parentTransform.Position, camera.Transform.WorldMatrix.Translation);
        }
    }
}