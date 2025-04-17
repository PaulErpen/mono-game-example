using System.IO;

namespace MonoGameExample.Scene.Loading
{
    public class SceneLoader
    {
        public static GameObject LoadScene(string sceneName)
        {
            if (!File.Exists(sceneName))
            {
                throw new FileNotFoundException($"Scene file {sceneName} not found.");
            }

            if (!sceneName.EndsWith(".yaml"))
            {
                throw new InvalidDataException($"Scene file {sceneName} is not a YAML file.");
            }

            var yaml = File.ReadAllText(sceneName);

            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                .WithNamingConvention(YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention.Instance)
                .Build();
            var scene = deserializer.Deserialize<RawSceneNode>(yaml);

            return new GameObject(scene.Name);
        }
    }
}