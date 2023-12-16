using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.Core;

namespace MyGame6
{
    public class ChangeScene : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        Scene CurrentScene;
        Scene BepuScene;
        Scene OriginalBodyScene;
        Vector3 originalCubePosition;
        Vector3 originalSpherePosition;
        public override void Start()
        {
            // Initialization of the script.
            BepuScene = Content.Load<Scene>("BepuScene");
            OriginalBodyScene = Content.Load<Scene>("OriginalBodyScene");
            SceneSystem.SceneInstance.RootScene.Children.Add(BepuScene);
            CurrentScene = BepuScene;
            (originalCubePosition, originalSpherePosition) = GetPosition(CurrentScene);
        }

        public override void Update()
        {
            if(Input.IsKeyPressed(Keys.D1) && CurrentScene != BepuScene)
            {
                SceneSystem.SceneInstance.RootScene.Children.Remove(CurrentScene);
                SceneSystem.SceneInstance.RootScene.Children.Add(BepuScene);
                CurrentScene = BepuScene;
                ResetPosition(CurrentScene);
            }
            else if(Input.IsKeyPressed(Keys.D2) && CurrentScene != OriginalBodyScene)
            {
                SceneSystem.SceneInstance.RootScene.Children.Remove(CurrentScene);
                SceneSystem.SceneInstance.RootScene.Children.Add(OriginalBodyScene);
                CurrentScene = OriginalBodyScene;
                ResetPosition(CurrentScene);
            }
        }
        (Vector3 spherePosition, Vector3 cubePosition) GetPosition(Scene scene)
        {
            Vector3 spherePosition = Vector3.Zero;
            Vector3 cubePosition = Vector3.Zero;
            foreach(var entity in scene.Entities)
            {
                if(entity.Name == "Sphere")
                {
                    spherePosition = entity.Transform.Position;
                }
                else if(entity.Name == "Cube")
                {
                    cubePosition = entity.Transform.Position;
                }
            }
            return (spherePosition, cubePosition);
        }
        void ResetPosition(Scene scene)
        {
            foreach(var entity in scene.Entities)
            {
                if(entity.Name == "Sphere")
                {
                    entity.Transform.Position = originalSpherePosition;
                }
                else if(entity.Name == "Cube")
                {
                    entity.Transform.Position = originalCubePosition;
                }
            }
        }
    }
}
