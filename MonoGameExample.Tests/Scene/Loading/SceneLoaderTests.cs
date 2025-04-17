using System.IO;
using Xunit;

namespace MonoGameExample.Scene.Loading
{
    public class SceneLoaderTests
    {
        [Fact]
        public void TestSceneLoaderFileNotFound()
        {
            // Arrange
            var sceneName = "non_existent_scene.yaml";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => SceneLoader.LoadScene(sceneName));
        }

        [Fact]
        public void TestSceneLoaderInvalidFileType()
        {
            // Arrange
            var sceneName = "../../../../MonoGameExample.Tests/Scenes/wrong-format-scene.json";

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => SceneLoader.LoadScene(sceneName));
        }
    }
}