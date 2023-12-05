using System;
using UnityEngine;

public class AnimatorMediator : MonoBehaviour
{
    [SerializeField] private WorkerAnimator _workerAnimator;
    private IWorkHandler _workHandler;
    private IMoveble _unitMover;

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
        _workHandler = GetComponent<IWorkHandler>();
    }

    private void Update()
    {
        UpdateMoveAnimation();
        UpdateWorkAnimation();
    }

    private void UpdateWorkAnimation()
    {
        if (_workHandler.IsWorking)
        {
            _workerAnimator.StartWork();
        }

        else
        {
            _workerAnimator.StopWork();
        }
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
