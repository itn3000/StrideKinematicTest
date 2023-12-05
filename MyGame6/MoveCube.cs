using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;

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
            var position = Entity.Transform.Position;
            if(Input.IsKeyDown(Keys.Left))
            {
                position.X -= moveAmmount;
            }
            else if(Input.IsKeyDown(Keys.Right))
            {
                position.X += moveAmmount;
            }
            if(Input.IsKeyDown(Keys.Up))
            {
                position.Z -= moveAmmount;
            }
            else if(Input.IsKeyDown(Keys.Down))
            {
                position.Z += moveAmmount;
            }
            Entity.Transform.Position = position;
            Entity.Transform.UpdateLocalFromWorld();
        }
    }
}
