using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBootstraper : MonoBehaviour, ICoroutineRunner
{
    private Game _game;
    private void Awake()
    {
        _game = new Game(this);
        _game.StateMachine.Enter<BootstrapState>();
            
        DontDestroyOnLoad(this);
    }
}