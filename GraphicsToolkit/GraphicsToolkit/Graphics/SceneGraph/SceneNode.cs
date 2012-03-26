using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GraphicsToolkit.Graphics.SceneGraph
{
    public partial class SceneNode : ISceneNode
    {
        protected List<ISceneNode> _children;
        protected Matrix _localTransform, _pivotTransform;
        protected Vector3 _position, _scale, _pivot;
        protected Quaternion _rotate;

        public SceneNode()
        {
            _children = new List<ISceneNode>();
            _position = Vector3.Zero;
            _scale = Vector3.One;
            _rotate = Quaternion.Identity;

            SetPivot(Vector3.Zero);
        }

        public void AddChild(ISceneNode node)
        {
            _children.Add(node);
        }

        public void RemoveChild(ISceneNode node)
        {
            _children.Remove(node);
        }

        public void SetPosition(Vector3 position)
        {
            _position = position;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public void SetScale(Vector3 scale)
        {
            _scale = scale;
        }

        public void SetRotation(Quaternion rotate)
        {
            _rotate = rotate;
        }

        public void SetPivot(Vector3 pivot)
        {
            _pivot = pivot;
            _pivotTransform = Matrix.CreateTranslation(-_pivot);
        }

        public void Draw(GameTime time, Matrix parentTransform, PrimitiveBatch primitiveBatch, Camera camera)
        {
            _localTransform = Matrix.CreateScale(_scale) * Matrix.CreateFromQuaternion(_rotate) * Matrix.CreateTranslation(_position);
            Matrix finalTransform = _pivotTransform * _localTransform * parentTransform;
            InternalDraw(time, finalTransform, primitiveBatch, camera);

            foreach (ISceneNode node in _children)
            {
                node.Draw(time, Matrix.Invert(_pivotTransform) * finalTransform, primitiveBatch, camera);
            }
        }

        public void Update(GameTime time)
        {
            InternalUpdate(time);

            foreach (ISceneNode node in _children)
            {
                node.Update(time);
            }
        }

        protected virtual void InternalUpdate(GameTime time)
        {

        }

        protected virtual void InternalDraw(GameTime time, Matrix absoluteTransform, PrimitiveBatch primitiveBatch, Camera camera)
        {

        }
    }
}
