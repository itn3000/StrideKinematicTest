using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using FFmpeg.AutoGen.Native;
using Stride.BepuPhysics;

namespace MyGame6
{
    public class DisplayBepuParameter : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public int PositionY = 100;
        public int PositionX = 10;
        public override void Start()
        {
        }

        public override void Update()
        {
            var bodycontainer = Entity.Get<BodyComponent>();
            if(bodycontainer != null)
            {
                DebugText.Print($"{bodycontainer.SpringFrequency},{bodycontainer.SpringDampingRatio}", new Int2(PositionX, PositionY));
            }
        }
    }
}
