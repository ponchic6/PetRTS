﻿using System;
using UnityEngine;

public class AnimatorMediator : MonoBehaviour
{
    [SerializeField] private WorkerAnimator _workerAnimator;
    [SerializeField] private UnitBuildingHandler _unitBuildingHandler;
    [SerializeField] private UnitResourceHandler _unitResourceHandler;
    private IMoveble _unitMover;

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();

        _unitBuildingHandler.OnStartWorking += StartWorking;
        _unitBuildingHandler.OnStopWorking += StopWorking;
        
        _unitResourceHandler.OnStartWorking += StartWorking;
        _unitResourceHandler.OnStopWorking += StopWorking;
    }

    private void Update()
    {
        UpdateMoveAnimation();
    }

    private void StartWorking()
    {
        _workerAnimator.StartWork();
    }

    private void StopWorking()
    {
        _workerAnimator.StopWork();
    }

    private void UpdateMoveAnimation()
    {
        if (_unitMover.GetCurrentSpeed().magnitude > 0)
        {
            _workerAnimator.Move();
        }

        else
        {
            _workerAnimator.StopMove();
        }
    }
}
