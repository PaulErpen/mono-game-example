using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGameExample.Component;
using MonoGameExample.Rendering;
using MonoGameExample.Rendering.GraphicsDeviceWrapper;

namespace MonoGameExample.Scene
{
    public class GameObject : SceneNode
    {
        public string Name { get; set; }
        public Transform Transform { get; set; } = new Transform(null);
        public List<IComponent> Components { get; } = new List<IComponent>();
        public List<SceneNode> Children { get; } = new List<SceneNode>();

        public GameObject(string name)
        {
            Name = name;
        }

        public void AddChild(SceneNode child)
        {
            if (child == null) throw new ArgumentNullException(nameof(child));
            Children.Add(child);
        }

        public void RemoveChild(SceneNode child)
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

        public void Initialize()
        {
            foreach (var component in Components)
            {
                component.Initialize();
            }
            foreach (var child in Children)
            {
                child.Initialize();
            }
        }

        public void Update(GameTime gameTime, Camera camera, IGraphicsDeviceWrapper graphicsDevice)
        {
            var frameContext = new FrameContext(gameTime, camera, graphicsDevice, this);
            foreach (var component in Components)
            {
                component.Update(frameContext);
            }
            foreach (var child in Children)
            {
                if (child is GameObject gameObject)
                {
                    gameObject.Update(gameTime, camera, graphicsDevice);
                }
            }
        }
    }
}
