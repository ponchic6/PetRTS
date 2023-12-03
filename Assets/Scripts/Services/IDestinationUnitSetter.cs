using System;
using UnityEngine;

public interface IDestinationUnitSetter
{
    public event Action<Vector3> OnSetDestination;
}