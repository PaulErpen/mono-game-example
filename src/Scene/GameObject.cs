using System;
using System.Collections.Generic;

namespace mono_game_example.Scene
{
    public class GameObject
    {
        public string Name { get; set; }
        public Transform Transform { get; set; } = new Transform();
        public List<GameObject> Children { get; } = new List<GameObject>();

        public GameObject(string name)
        {
            Name = name;
        }

        public void AddChild(GameObject child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            child.Transform.Parent = Transform;
            Children.Add(child);
        }

        public void RemoveChild(GameObject child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            child.Transform.Parent = null;
            Children.Remove(child);
        }
        public void UpdateWorldMatrix()
        {
            Transform.UpdateWorldMatrix();
            foreach (var child in Children)
            {
                child.UpdateWorldMatrix();
            }
        }
    }
}