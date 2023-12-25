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
    public class GravityChange : SyncScript
    {
        // Declared public member fields and properties will show in the game studio

        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            var container = Entity.Get<BodyContainerComponent>();
            if (Entity.Transform.Position.Y < 4.0f)
            {
                container.Simulation.PoseGravity = new Vector3(0, 9.8f, 0);
            }
            else
            {
                container.Simulation.PoseGravity = new Vector3(0, -9.8f, 0);
            }
        }
    }
}
