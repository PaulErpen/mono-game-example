namespace MonoGameExample.Scene
{
    public interface SceneNode
    {
        string Name { get; set; }
        Transform Transform { get; set; }
        public void Initialize();
        public void UpdateWorldMatrix(Transform Parent);
    }
}