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
    public class DisplayPosition : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public int PositionY = 60;
        public int PositionX = 10;

        public override void Start()
        {
        }

        public override void Update()
        {
            DebugText.Print($"{Entity.Name}: {Entity.Transform.Position} | {Entity.Transform.Rotation}", new Int2(PositionX, PositionY));
        }
    }
}
