using UnityEngine;
using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly SceneLoader _sceneLoader;

    [Inject] private IUIHandlerFactory _uiHandlerFactory;
    [Inject] private IUIFactory _uiFactory;

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
        _uiFactory.CreatBuildingListPanel();
        _uiFactory.CreateBuildButtons();
        _uiFactory.CreatePanelOfSelectedObjects();
        _uiHandlerFactory.CreateViewSelector();
    }
}