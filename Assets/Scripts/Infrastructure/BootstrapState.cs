﻿public class BootstrapState : IState
{
    private const string Initial = "Initial";
    private readonly GameStateMachine _stateMachine;
    private SceneLoader _sceneLoader;
    public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }
    public void Enter()
    {
        _sceneLoader.Load(Initial, EnterLoadLevel);
        
    }

    public void Exit()
    {
        
    }

    private void EnterLoadLevel() 
        => _stateMachine.Enter<LoadLevelState, string>("Level");
}