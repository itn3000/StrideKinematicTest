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
    public class ChangeScene : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        Scene CurrentScene;
        public override void Start()
        {
            // Initialization of the script.
            foreach(var scene in SceneSystem.SceneInstance.RootScene.Children)
            {
                if(scene.Name.Equals("BepuScene", StringComparison.OrdinalIgnoreCase))
                {
                    CurrentScene = scene;
                    // SceneSystem.Ac
                    break;
                }
            }
        }

        public override void Update()
        {
            if(Input.IsKeyPressed(Keys.D1))
            {
                
            }
        }
    }
}
