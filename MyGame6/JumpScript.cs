using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.BepuPhysics;

namespace MyGame6
{
    public class JumpScript : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public float JumpForce = 10.0f;
        public override void Start()
        {
            // Initialization of the script.
        }

        public override void Update()
        {
            if(Input.IsKeyPressed(Keys.Space))
            {
                var container = Entity.Get<BodyComponent>();
                container.ApplyLinearImpulse(Vector3.UnitY * JumpForce);
            }
        }
    }
}
