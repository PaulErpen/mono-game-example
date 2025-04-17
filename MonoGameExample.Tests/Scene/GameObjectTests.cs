using Microsoft.Xna.Framework;
using MonoGameExample.Component;
using MonoGameExample.Rendering;
using MonoGameExample.Rendering.GraphicsDeviceWrapper;
using MonoGameExample.Scene;
using Moq;
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

        [Fact]
        public void TestGameObjectInitialize()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");
            var component = new Mock<IComponent>();
            gameObject.Components.Add(component.Object);

            // Act
            gameObject.Initialize();

            // Assert
            component.Verify(c => c.Initialize(), Times.Once);
        }

        [Fact]
        public void TestGameObjectUpdate()
        {
            // Arrange
            var gameObject = new GameObject("TestObject");
            var component = new Mock<IComponent>();
            gameObject.Components.Add(component.Object);
            var gameTime = new GameTime();
            var camera = new Mock<Camera>("Camera", true);
            var graphicsDeviceWrapper = new Mock<IGraphicsDeviceWrapper>();

            // Act
            gameObject.Update(gameTime, camera.Object, graphicsDeviceWrapper.Object);

            // Assert
            component.Verify(c => c.Update(It.IsAny<FrameContext>()), Times.Once);
        }

        [Fact]
        public void TestGameObjectChildUpdate()
        {
            // Arrange
            var parent = new GameObject("Parent");
            var child = new GameObject("Child");
            parent.AddChild(child);
            var component = new Mock<IComponent>();
            child.Components.Add(component.Object);
            var gameTime = new GameTime();
            var camera = new Mock<Camera>("Camera", true);
            var graphicsDeviceWrapper = new Mock<IGraphicsDeviceWrapper>();

            // Act
            parent.Update(gameTime, camera.Object, graphicsDeviceWrapper.Object);

            // Assert
            component.Verify(c => c.Update(It.Is<FrameContext>(f => f.GameObject.Equals(child))), Times.Once);
        }
    }
}
