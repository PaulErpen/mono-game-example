using System.Collections.Generic;

namespace MonoGameExample.Scene.Loading
{
    public class RawSceneNode
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<RawSceneNode> Children { get; set; } = new List<RawSceneNode>();
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
    }
}