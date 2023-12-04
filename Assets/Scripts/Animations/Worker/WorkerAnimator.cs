using System;
using UnityEngine;

public class WorkerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int Work = Animator.StringToHash("Work");

    public void StartWork()
    {
        _animator.SetBool(IsMoving, false);
        _animator.SetBool(Work, true);
    }

    public void StopWork()
    {
        _animator.SetBool(Work, false);
    }
    public void Move() 
        => _animator.SetBool(IsMoving, true);

    public void StopMove() 
        => _animator.SetBool(IsMoving, false);
}
        
