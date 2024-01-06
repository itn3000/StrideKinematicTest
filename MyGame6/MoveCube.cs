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
            foreach (var sys in Game.GameSystems)
            {
                Log.Info($"sysname: {sys.Name}");
            }
            var bodycontainer = Entity.Get<BodyContainerComponent>();
            Log.Info($"{bodycontainer.SimulationIndex}, {bodycontainer.Simulation.Enabled}, {bodycontainer.Simulation.PoseGravity}");
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
            var bodycontainer = Entity.Get<BodyContainerComponent>();
            bodycontainer.Position += moveVector;
            bodycontainer.Orientation = rotation;
            //bodycontainer.Colliders[0].PositionLocal += moveVector;
            bodycontainer.Awake = true;
            var colliderpos = bodycontainer.Colliders[0].PositionLocal;
            DebugText.Print($"bodycontainer position: {bodycontainer.Position}, colliderpos: {colliderpos}", new Int2(10, 40));
            Entity.Transform.UpdateWorldMatrix();
        }
    }
}
