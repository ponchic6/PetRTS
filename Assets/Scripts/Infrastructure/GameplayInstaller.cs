using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private TickService _tickService;
    private CameraMoverService _cameraMoverService;
    private InputService _inputService;
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
        BuildingService buildingService = Container.Instantiate<BuildingService>();
        Container.Bind<BuildingService>().FromInstance(buildingService).AsSingle();
    }

    private void RegisterBuildingFactory()
    {
        BuildingFactory buildingFactory = Container.Instantiate<BuildingFactory>();
        Container.Bind<BuildingFactory>().FromInstance(buildingFactory).AsSingle();
    }

    private void RegisterInputService()
    {
        _inputService = Container.Instantiate<InputService>();
        Container.Bind<IInputService>().FromInstance(_inputService).AsSingle();
    }

    private void RegisterCameraMoveService()
    {
        _cameraMoverService = Container.Instantiate<CameraMoverService>();
        Container.Bind<ICameraMoverService>().FromInstance(_cameraMoverService).AsSingle();
    }

    private void RegisterTickService()
    {
        Container.Bind<ITickService>().FromInstance(_tickService).AsSingle();
    }
}