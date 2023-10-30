using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterCameraMoveService();
        RegisterBuildingFactory();
        RegisterBuildingService();
    }

    private void RegisterBuildingService()
    {
        IBuildingService buildingService = Container.Instantiate<BuildingService>();
        Container.Bind<IBuildingService>().FromInstance(buildingService).AsSingle();
    }

    private void RegisterBuildingFactory()
    {
        IBuildingFactory buildingFactory = Container.Instantiate<BuildingFactory>();
        Container.Bind<IBuildingFactory>().FromInstance(buildingFactory).AsSingle();
    }

    private void RegisterInputService()
    {
        IInputService inputService = Container.Instantiate<InputService>();
        Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
    }

    private void RegisterCameraMoveService()
    {
        ICameraMoverService cameraMoverService = Container.Instantiate<CameraMoverService>();
        Container.Bind<ICameraMoverService>().FromInstance(cameraMoverService).AsSingle();
    }

    private void RegisterTickService()
    {    
        GameObject tickObject = new GameObject("TickService");
        DontDestroyOnLoad(tickObject);
        ITickService tickService = tickObject.AddComponent<TickService>();
        Container.Bind<ITickService>().FromInstance(tickService).AsSingle();
    }
}