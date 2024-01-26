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
using Stride.BepuPhysics.Components;
using Stride.BepuPhysics;

namespace MyGame6
{
    public class SpringValueChanged : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        Entity SphereBepu;
        Entity CubeBepu;
        const string SphereSpringFrequencyName = "SphereSpringFrequency";
        const string SphereSpringDampingRatioName = "SphereSpringDampingRatio";
        const string CubeSpringFrequencyName = "CubeSpringFrequency";
        const string CubeSpringDampingRatioName = "CubeSpringDampingRatio";

        public override void Start()
        {
            // Initialization of the script.
            var ui = Entity.Get<UIComponent>();
            SetupSphereMenu(ui);
            SetupCubeMenu(ui);
            //UpdateCubeProperty(ui.Page.RootElement.FindVisualChildOfType<Slider>(CubeSpringFrequencyName), cubeEntity);
            //UpdateCubeProperty(ui.Page.RootElement.FindVisualChildOfType<Slider>(CubeSpringDampingRatioName), cubeEntity);
        }

        void SetupSphereMenu(UIComponent ui)
        {
            var sphereEntity = FindSphereBepu();
            var sphereContainer = sphereEntity.Get<Stride.BepuPhysics.ContainerComponent>();
            var sphereSpring = ui.Page.RootElement.FindVisualChildOfType<Slider>(SphereSpringFrequencyName);
            sphereSpring.Value = sphereContainer.SpringFrequency;
            sphereSpring.ValueChanged += SphereSpring_ValueChanged;
            var sphereDampingRatio = ui.Page.RootElement.FindVisualChildOfType<Slider>(SphereSpringDampingRatioName);
            sphereDampingRatio.Value = sphereContainer.SpringDampingRatio;
            sphereDampingRatio.ValueChanged += SphereDampingRatio_ValueChanged;
            UpdateSphereProperty(ui);
        }

        void SetupCubeMenu(UIComponent ui)
        {
            var cubeEntity = FindCubeBepu();
            var cubeBody = cubeEntity.Get<BodyComponent>();
            var cubeSpring = ui.Page.RootElement.FindVisualChildOfType<Slider>(CubeSpringFrequencyName);
            cubeSpring.Value = cubeBody.SpringFrequency;
            cubeSpring.ValueChanged += (sender, ev) => UpdateCubeProperty(ev.Source, cubeEntity);
            var cubeDampingRatio = ui.Page.RootElement.FindVisualChildOfType<Slider>(CubeSpringDampingRatioName);
            cubeDampingRatio.Value = cubeBody.SpringDampingRatio;
            cubeDampingRatio.ValueChanged += (sender, ev) => UpdateCubeProperty(ev.Source, cubeEntity);
        }

        Entity FindCubeBepu()
        {
            foreach(var entity in SceneSystem.SceneInstance.Where(x => x.Name == "CubeBepu"))
            {
                return entity;
            }
            return null;
        }

        void UpdateCubeProperty(UIElement element, Entity cubeBepu)
        {
            var bodycontainer = cubeBepu.Get<BodyComponent>();
            if(element is Slider slider)
            {
                if (element.Name == "CubeSpringFrequency")
                {
                    bodycontainer.SpringFrequency = slider.Value;
                }
                else if (element.Name == "CubeDampingRatio")
                {
                    bodycontainer.SpringDampingRatio = slider.Value;
                }
            }

        }

        private void SphereDampingRatio_ValueChanged(object sender, Stride.UI.Events.RoutedEventArgs e)
        {
            var ui = Entity.Get<UIComponent>();
            UpdateSphereProperty(ui);
        }

        private void SphereSpring_ValueChanged(object sender, Stride.UI.Events.RoutedEventArgs e)
        {
            if(e.Source is Slider slider)
            {
                Log.Info($"sphere spring freq value:{slider.Value}");
            }
            var ui = Entity.Get<UIComponent>();
            UpdateSphereProperty(ui);
        }

        void UpdateSphereProperty(UIComponent ui)
        {
            var sphereBepu = FindSphereBepu();
            SphereBepu = sphereBepu;
            var bodycontainer = sphereBepu.Get<BodyComponent>();
            if (ui != null && bodycontainer != null)
            {
                var sphereSpring = ui.Page.RootElement.FindVisualChildOfType<Slider>("SphereSpringFrequency");
                if (sphereSpring != null)
                {
                    Log.Info($"{sphereSpring.Name} = {sphereSpring.Value}");
                    bodycontainer.SpringFrequency = sphereSpring.Value;
                }
                var sphareDamping = ui.Page.RootElement.FindVisualChildOfType<Slider>("SphereSpringDampingRatio");
                if (sphareDamping != null)
                {
                    Log.Info($"{sphareDamping.Name} = {sphareDamping.Value}");
                    bodycontainer.SpringDampingRatio = sphareDamping.Value;
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

            DebugText.Print($"", new Int2(10, 500));
        }
    }
}
