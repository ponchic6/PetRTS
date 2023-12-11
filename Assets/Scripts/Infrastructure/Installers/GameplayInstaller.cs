using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private StaticData _staticData;
    public override void InstallBindings()
    {
        RegisterStaticData();
        RegisterTickService();
        RegisterInputService();
        RegisterCameraMoveService();
        RegisterSelectableListService();
        RegisterUIHandlerFactory();
        RegisterUIFactory();
        RegisterDestinationSetter();
        RegisterWarriorFactory();
        RegisterBuildingFactory();
        RegisterSelectorService();
        RegisterGlobalResourceStorageService();
        RegisterGlobalResourceAndBuildingFactoryMediator();
        RegisterBuildingService();
    }

    private void RegisterGlobalResourceAndBuildingFactoryMediator()
    {
        IGlobalResourceAndBuildingFactoryMediator mediator =
            Container.Instantiate<GlobalResourceAndBuildingFactoryMediator>();
        Container.Bind<IGlobalResourceAndBuildingFactoryMediator>().FromInstance(mediator).AsSingle();
    }

    private void RegisterStaticData()
    {
        Container.Bind<StaticData>().FromInstance(_staticData).AsSingle();
    }

    private void RegisterGlobalResourceStorageService()
    {
        IGlobalResourcessStorageService globalResourcessStorageService =
            Container.Instantiate<GlobalResourcessStorageService>();
        Container.Bind<IGlobalResourcessStorageService>().FromInstance(globalResourcessStorageService).AsSingle();
    }

    private void RegisterDestinationSetter()
    {
        IDestinationOfGroupUnitsSetter destinationOfGroupUnitsSetter = Container.Instantiate<DestinationOfGroupUnitsSetter>();
        Container.Bind<IDestinationOfGroupUnitsSetter>().FromInstance(destinationOfGroupUnitsSetter).AsSingle();
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