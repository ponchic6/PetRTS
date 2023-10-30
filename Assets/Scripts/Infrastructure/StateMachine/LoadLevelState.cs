using System;
using UnityEngine;
using Zenject;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly DiContainer _diContainer;
    private readonly SceneLoader _sceneLoader;
    
    private readonly UIFactory _uiFactory;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, DiContainer diContainer)
    {
        _diContainer = diContainer;
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;

        _uiFactory = _diContainer.Instantiate<UIFactory>();
    }

    public void Enter(string sceneName) 
        => _sceneLoader.Load(sceneName, OnLoaded);

    public void Exit()
    {
        
    }

    private void OnLoaded()
    {
        Transform rootCanvas = _uiFactory.CreatCanvas();
        Transform buildingListPanel = _uiFactory.CreatBuildingListPanel();
        Transform buildingButtons = _uiFactory.CreateBuildButtons();
    }
}