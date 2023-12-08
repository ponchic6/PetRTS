using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly SceneLoader _sceneLoader;
    
    [Inject] private IUIFactory _uiFactory;
    [Inject] private IUnitFactory _unitFactory;
    [Inject] private IUIHandlerFactory _uiHandlerFactory;
    [Inject] private StaticData _staticData;

    public LoadLevelState(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Enter(string sceneName) 
        => _sceneLoader.Load(sceneName, OnLoaded);

    public void Exit()
    {
        
    }

    private void OnLoaded()
    {
        _uiFactory.CreatCanvas();
        _uiFactory.CreatCreationPanel();
        _uiFactory.CreatePanelOfSelectedObjects();
        _uiFactory.CreateResourceCountPanel();
        _unitFactory.CreateUnit(_staticData.UnitStaticDataWorker);
        _unitFactory.CreateUnit(_staticData.UnitStaticDataWorker);
        _unitFactory.CreateUnit(_staticData.UnitStaticDataWorker);
        _uiHandlerFactory.CreateSelectorView();
    }
}