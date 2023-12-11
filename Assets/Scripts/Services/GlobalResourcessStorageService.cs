using System;
using TMPro;
using UnityEngine;

public class GlobalResourcessStorageService : IGlobalResourcessStorageService
{
    public event Action OnChangeResourceCount;
    
    private float _storageResource;

    public float StorageResource => _storageResource;

    public GlobalResourcessStorageService()
    {
        AddResource(100);
    }

    public void AddResource(float resourceCount)
    {
        _storageResource += resourceCount;
        OnChangeResourceCount?.Invoke();
    }

    public void RemoveResource(float resourceCount)
    {
        _storageResource -= resourceCount;

        if (_storageResource <= 0)
        {
            _storageResource = 0;
        }
        
        OnChangeResourceCount?.Invoke();
    }
}