using TMPro;
using UnityEngine;

public class GlobalResourcessStorageService : IGlobalResourcessStorageService
{
    private float _storageResource;
    private IUIFactory _uiFactory;

    public GlobalResourcessStorageService(IUIFactory uiFactory)
    {
        _uiFactory = uiFactory;
    }
    public void AddResource(float currentResourceCount)
    {
        _storageResource += currentResourceCount;
        _uiFactory.ResourceCountPanel.GetComponentInChildren<TMP_Text>().text = _storageResource.ToString();
    }
}