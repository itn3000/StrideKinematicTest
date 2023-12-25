using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.UI;
using Stride.UI.Controls;
using Stride.BepuPhysics.Components.Containers;

namespace MyGame6
{
    public class SpringValueChanged : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        Entity SphereBepu;

        public override void Start()
        {
            // Initialization of the script.
            var ui = Entity.Get<UIComponent>();
            var sphereBepu = FindSphereBepu();
            SphereBepu = sphereBepu;
            if(ui != null)
            {
                var sphereSpring = ui.Page.RootElement.FindVisualChildOfType<Slider>("SphereSpringFrequency");
                if (sphereSpring != null)
                {
                    Log.Info($"{sphereSpring.Name} = {sphereSpring.Value}");
                    var bodycontainer = sphereBepu.Get<BodyContainerComponent>();
                    if(bodycontainer != null)
                    {
                        bodycontainer.SpringFrequency = sphereSpring.Value;
                    }
                }
            }
        }

        Entity FindSphereBepu()
        {
            foreach (var entity in SceneSystem.SceneInstance.Where(x => x.Name == "SphereBepu"))
            {
                if(entity.Name == "SphereBepu")
                {
                    return entity;
                }
            }
            return null;
        }

        public override void Update()
        {
            var sphere = FindSphereBepu();

        }
    }
}
