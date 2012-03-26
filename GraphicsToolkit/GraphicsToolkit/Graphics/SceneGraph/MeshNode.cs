using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GraphicsToolkit.Graphics.SceneGraph
{
    public partial class MeshNode : SceneNode, ISceneNode
    {
        private Mesh _mesh;

        public Mesh Mesh
        {
            get { return _mesh; }
            set { _mesh = value; }
        }

        public MeshNode()
        {
            _children = new List<ISceneNode>();
            _position = Vector3.Zero;
            _scale = Vector3.One;
            _rotate = Quaternion.Identity;

            SetPivot(Vector3.Zero);
        }

        protected override void InternalDraw(GameTime time, Matrix absoluteTransform, PrimitiveBatch primitiveBatch, Camera camera)
        {
            if (_mesh != null)
            {
                primitiveBatch.DrawMesh(_mesh, absoluteTransform, camera);
            }
        }
    }
}