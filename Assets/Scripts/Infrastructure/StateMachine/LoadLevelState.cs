using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly SceneLoader _sceneLoader;
    
    [Inject] private IUIFactory _uiFactory;
    [Inject] private IUnitFactory _unitFactory;
    [Inject] private IUIHandlerFactory _uiHandlerFactory;

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
        _unitFactory.CreateUnit(new Worker());
        _uiHandlerFactory.CreateSelectorView();
    }
}