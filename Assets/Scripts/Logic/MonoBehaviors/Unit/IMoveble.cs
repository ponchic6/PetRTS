using System.Collections;
using UnityEngine;

public interface IMoveble
{
    public void MoveToDestination(Vector3 destination, GameObject rotateToObject = null);
    public Vector3 CurrentSpeed { get; }
    public Transform Transform { get; }
    public UnitStaticData UnitStaticData { get; }
}