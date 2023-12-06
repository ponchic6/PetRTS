using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterCameraMoveService();
        RegisterSelectableListService();
        RegisterUIHandlerFactory();
        RegisterUIFactory();
        RegisterDestinationSetter();
        RegisterWarriorFactory();
        RegisterBuildingFactory();
        RegisterBuildingService();
        RegisterSelectorService();
        RegisterGlobalResourceStorageService();
    }

    private void RegisterGlobalResourceStorageService()
    {
        IGlobalResourcessStorageService globalResourcessStorageService =
            Container.Instantiate<GlobalResourcessStorageService>();
        Container.Bind<IGlobalResourcessStorageService>().FromInstance(globalResourcessStorageService).AsSingle();
    }

    private void RegisterDestinationSetter()
    {
        IDestinationUnitSetter destinationUnitSetter = Container.Instantiate<DestinationUnitSetter>();
        Container.Bind<IDestinationUnitSetter>().FromInstance(destinationUnitSetter).AsSingle();
    }

    private void RegisterWarriorFactory()
    {
        IUnitFactory unitFactory = Container.Instantiate<UnitFactory>();
        Container.Bind<IUnitFactory>().FromInstance(unitFactory).AsSingle();
    }

    private void RegisterSelectableListService()
    {
        SelectableListService selectableListService = Container.Instantiate<SelectableListService>();
        Container.Bind<SelectableListService>().FromInstance(selectableListService).AsSingle();
    }

    private void RegisterUIHandlerFactory()
    {
        UIHandlerFactory uiHandlerFactory = Container.Instantiate<UIHandlerFactory>();
        Container.Bind<IUIHandlerFactory>().FromInstance(uiHandlerFactory).AsSingle();
    }

    private void RegisterUIFactory()
    {
        UIFactory uiFactory = Container.Instantiate<UIFactory>();
        Container.Bind<IUIFactory>().FromInstance(uiFactory).AsSingle();
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