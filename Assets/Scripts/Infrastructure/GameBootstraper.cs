using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class GameBootstraper : MonoBehaviour, ICoroutineRunner
{
    private Game _game;
    private DiContainer _diContainer;
    
    [Inject]
    public void Constructor(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }
    private void Awake()
    {
        _game = new Game(this, _diContainer);
        _game.StateMachine.Enter<BootstrapState>();
            
        DontDestroyOnLoad(this);
    }
}