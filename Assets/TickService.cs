using System;
using UnityEngine;

public class TickService : MonoBehaviour, ITickService
{
    public event Action OnTick;
    public event Action OnFixedTick;
    public event Action OnLateTick;

    private void Update() => OnTick?.Invoke();
    private void FixedUpdate() => OnFixedTick?.Invoke();
    private void LateUpdate() => OnLateTick?.Invoke();
}