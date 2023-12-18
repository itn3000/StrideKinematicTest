using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.BepuPhysics.Components.Containers;

namespace MyGame6
{
    public class MoveCube : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            const float moveAmmount = 0.1f;
            const float rotateAmount = 0.01f;
            var moveVector = Vector3.Zero;
            var rotation = Entity.Transform.Rotation;
            if(Input.IsKeyDown(Keys.Left))
            {
                moveVector.X -= moveAmmount;
            }
            else if(Input.IsKeyDown(Keys.Right))
            {
                moveVector.X += moveAmmount;
            }
            if(Input.IsKeyDown(Keys.Up))
            {
                moveVector.Z -= moveAmmount;
            }
            else if(Input.IsKeyDown(Keys.Down))
            {
                moveVector.Z += moveAmmount;
            }
            if(Input.IsKeyDown(Keys.C))
            {
                moveVector.Y -= moveAmmount;
            }
            if(Input.IsKeyDown(Keys.U))
            {
                moveVector.Y += moveAmmount;
            }
            if(Input.IsKeyDown(Keys.Q))
            {
                rotation *= Quaternion.RotationZ(rotateAmount);
            }
            if(Input.IsKeyDown(Keys.E))
            {
                rotation *= Quaternion.RotationZ(-rotateAmount);
            }
            Entity.Transform.Position += moveVector;
            Entity.Transform.Rotation = rotation;
            Entity.Transform.UpdateWorldMatrix();
            var bodycontainer = Entity.Get<BodyContainerComponent>();
            var collider = Entity.Get<Stride.BepuPhysics.Components.Colliders.BoxColliderComponent>();
            // kinematic rigidbody does not move without ApplyDescription?
            var physicBody = bodycontainer.GetPhysicBody();
            if(physicBody.HasValue)
            {
                var ph = physicBody.Value;
                ph.GetDescription(out var description);
                description.Pose.Position += new System.Numerics.Vector3(moveVector.X, moveVector.Y, moveVector.Z);
                description.Pose.Orientation = new System.Numerics.Quaternion(rotation.X, rotation.Y, rotation.Z, rotation.W);
                ph.ApplyDescription(description);
                DebugText.Print($"{ph.Pose.Position}", new Int2(10, 40));
            }
            DebugText.Print($"{bodycontainer.Kinematic}, {collider.Size}, {bodycontainer.Entity.Transform.Position}", new Int2(10, 10));
        }
    }
}
