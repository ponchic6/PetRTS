using System;
using System.Collections.Generic;
using Zenject;

public class GameStateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;
    public GameStateMachine(SceneLoader sceneLoader, DiContainer diContainer)
    {
        _states = new Dictionary<Type, IExitableState>(); 
        
        _states[typeof(BootstrapState)] = new BootstrapState(this, sceneLoader);
        _states[typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, diContainer);
        
    }
    
    public void Enter<TState>() where TState : class, IState
    {
        var state = ChangeState<TState>();
        state.Enter(); 
    }

    public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadState<TPayLoad>
    {
        var state = ChangeState<TState>();
        state.Enter(payLoad);
    }

    private TState GetState<TState>() where TState : class, IExitableState 
        => _states[typeof(TState)] as TState;

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
        _activeState?.Exit();
        
        TState state = GetState<TState>();
        _activeState = state;
        
        return state;
    }
}