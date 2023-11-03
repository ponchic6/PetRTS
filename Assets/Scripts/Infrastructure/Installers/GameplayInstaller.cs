using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        RegisterCameraMoveService();
        RegisterSelectableListService();
        RegisterBuildingFactory();
        RegisterBuildingService();
        RegisterSelectorService();

    }

    private void RegisterSelectableListService()
    {
        SelectableListService selectableListService = Container.Instantiate<SelectableListService>();
        Container.Bind<SelectableListService>().FromInstance(selectableListService).AsSingle();
    }

    private void RegisterSelectorService()
    {
        SelectorService selectorService = Container.Instantiate<SelectorService>();
        Container.Bind<ISelectorService>().FromInstance(selectorService).AsSingle();
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

    private void RegisterCameraMoveService()
    {
        ICameraMoverService cameraMoverService = Container.Instantiate<CameraMoverService>();
        Container.Bind<ICameraMoverService>().FromInstance(cameraMoverService).AsSingle();
    }

}