using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly DiContainer _diContainer;
    private readonly SceneLoader _sceneLoader;
    
    [Inject] private IUIFactory _uiFactory;
    [Inject] private IUIHandlerFactory _uiHandlerFactory;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader,
        DiContainer diContainer)
    {
        _diContainer = diContainer;
        _gameStateMachine = gameStateMachine;
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
        _uiFactory.CreatBuildingListPanel();
        _uiFactory.CreateBuildButtons();
        _uiFactory.CreatePanelOfSelectedObjects();
        _uiHandlerFactory.CreateSelectorView();
    }
}