// implement tests for Transform class
using Microsoft.Xna.Framework;
using MonoGameExample.Scene;
using Xunit;

namespace MonoGameExample.Tests.Scene
{
    public class TransformTests
    {
        [Fact]
        public void TestTransformInitialization()
        {
            // Arrange
            var transform = new Transform(null);

            // Act
            var worldMatrix = transform.WorldMatrix;

            // Assert
            Assert.Equal(Matrix.Identity, worldMatrix);
        }

        [Fact]
        public void TestTransformTranslation()
        {
            // Arrange
            var transform = new Transform(null);
            var translation = new Vector3(10, 20, 30);

            // Act
            transform.Position = translation;
            transform.UpdateWorldMatrix(null);
            var worldMatrix = transform.WorldMatrix;

            // Assert
            Assert.True(Matrix.CreateTranslation(translation).Equals(worldMatrix));
        }

        [Fact]
        public void TestTransformRotation()
        {
            // Arrange
            var transform = new Transform(null);
            var rotation = Quaternion.CreateFromAxisAngle(Vector3.Up, MathHelper.ToRadians(90));

            // Act
            transform.Rotation = rotation;
            transform.UpdateWorldMatrix(null);
            var worldMatrix = transform.WorldMatrix;

            // Assert
            Assert.True(Matrix.CreateFromQuaternion(rotation).Equals(worldMatrix));
        }

        [Fact]
        public void TestTransformScaling()
        {
            // Arrange
            var transform = new Transform(null);
            var scale = new Vector3(2, 2, 2);

            // Act
            transform.Scale = scale;
            transform.UpdateWorldMatrix(null);
            var worldMatrix = transform.WorldMatrix;

            // Assert
            Assert.True(Matrix.CreateScale(scale).Equals(worldMatrix));
        }

        [Fact]
        public void TestTransformParentChild()
        {
            // Arrange
            var parentTransform = new Transform(null);
            var childTransform = new Transform(null);
            var translation = new Vector3(10, 20, 30);

            // Act
            parentTransform.Position = translation;
            parentTransform.UpdateWorldMatrix(null);
            childTransform.UpdateWorldMatrix(parentTransform);
            var worldMatrix = childTransform.WorldMatrix;

            // Assert
            Assert.True(Matrix.CreateTranslation(translation).Equals(worldMatrix));
        }
    }
}