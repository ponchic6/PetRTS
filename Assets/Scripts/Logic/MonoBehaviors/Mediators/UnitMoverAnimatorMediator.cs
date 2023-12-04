using System;
using UnityEngine;

public class AnimatorMediator : MonoBehaviour
{
    [SerializeField] private WorkerAnimator _workerAnimator;
    [SerializeField] private WorkHandler _workHandler;
    private IMoveble _unitMover;

    private void Awake()
    {
        _unitMover = GetComponent<IMoveble>();
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
