using System;
using UnityEngine;

public class LoadLevelState : IPayLoadState<string>
{
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly UIFactory _uiFactory;

    public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, UIFactory uiFactory)
    {
        _uiFactory = uiFactory;
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
        Transform rootCanvas = _uiFactory.CreatCanvas();
        GameObject buildingListPanel = _uiFactory.CreatBuildingListPanel();
    }
}