using System.Collections;
using UnityEngine;

public interface IMoveble
{
    public void MoveToDestination(Vector3 destination);
    public Vector3 GetCurrentSpeed();
    public Transform GetTransform();
}