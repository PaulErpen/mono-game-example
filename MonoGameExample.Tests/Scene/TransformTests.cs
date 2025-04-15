// implement tests for Transform class
using System;
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
    }
}