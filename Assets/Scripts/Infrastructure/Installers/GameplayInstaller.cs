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
        RegisterWarriorFactory();
        RegisterBuildingFactory();
        RegisterBuildingService();
        RegisterSelectorService();

    }

    private void RegisterWarriorFactory()
    {
        IWarriorFactory warriorFactory = Container.Instantiate<WarriorFactory>();
        Container.Bind<IWarriorFactory>().FromInstance(warriorFactory).AsSingle();
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