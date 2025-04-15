using System;
using System.Collections.Generic;
using MonoGameExample.Component;

namespace MonoGameExample.Scene
{
    public class GameObject
    {
        public string Name { get; set; }
        public Transform Transform { get; set; } = new Transform(null);
        public List<IComponent> Components { get; } = new List<IComponent>();
        public List<GameObject> Children { get; } = new List<GameObject>();

        public GameObject(string name)
        {
            Name = name;
        }

        public void AddChild(GameObject child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            Children.Add(child);
        }

        public void RemoveChild(GameObject child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            Children.Remove(child);
        }

        public void UpdateWorldMatrix(Transform Parent)
        {
            Transform.UpdateWorldMatrix(Parent);

            foreach (var child in Children)
            {
                child.UpdateWorldMatrix(Transform);
            }
        }
    }
}