using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GraphicsToolkit.Graphics.SceneGraph
{
    public interface ISceneNode
    {
        void AddChild(ISceneNode node);
        void RemoveChild(ISceneNode node);
        void SetPosition(Vector3 position);
        Vector3 GetPosition();
        void SetScale(Vector3 scale);
        void SetRotation(Quaternion rotate);
        void SetPivot(Vector3 pivot);
        void Draw(GameTime time, Matrix parentTransform, PrimitiveBatch primitiveBatch, Camera camera);
        void Update(GameTime time);
    }
}
