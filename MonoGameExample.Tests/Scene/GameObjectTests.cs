using Microsoft.Xna.Framework;
using MonoGameExample.Scene;
using Xunit;

namespace MonoGameExample.Tests.Scene

{
    public class GameObjectTests
    {
        [Fact]
        public void TestGameObjectInitialization()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");

            // Act
            var name = gameObject.Name;

            // Assert
            Assert.Equal("TestObject", name);
        }

        [Fact]
        public void TestGameObjectAddChild()
        {
            // Arrange
            var parent = new GameObject("Parent");
            var child = new GameObject("Child");

            // Act
            parent.AddChild(child);

            // Assert
            Assert.Contains(child, parent.Children);
        }

        [Fact]
        public void TestGameObjectRemoveChild()
        {
            // Arrange
            var parent = new GameObject("Parent");
            var child = new GameObject("Child");
            parent.AddChild(child);

            // Act
            parent.RemoveChild(child);

            // Assert
            Assert.DoesNotContain(child, parent.Children);
        }

        [Fact]
        public void TestGameObjectUpdateWorldMatrix()
        {
            // Arrange
            var parent = new GameObject("Parent");
            var child = new GameObject("Child");
            parent.AddChild(child);
            var translation = new Vector3(10, 20, 30);
            parent.Transform.Position = translation;

            // Act
            parent.UpdateWorldMatrix(null);

            // Assert
            Assert.True(child.Transform.WorldMatrix.Equals(Matrix.CreateTranslation(translation)));
        }
    }
}
