using System;
using UnityEngine;
using Zenject;

public class SelectorView : MonoBehaviour
{
    private ISelectorService _selectorService;
    private Rect _rect;
    private bool _isCanDraw;

    [Inject]
    public void Constructor(ISelectorService selectorService)
    {
        _selectorService = selectorService;
        _selectorService.OnChangeRect += SetSelectRect;
        _selectorService.OnChangeDrawStatus += SetCanDrawStatus;
    }

    private void OnGUI()
    {
        if (_isCanDraw)
            GUI.Box(_rect, "");
    }

    private void SetSelectRect(Rect rect)
    {
        _rect = rect;
    }

    private void SetCanDrawStatus(bool isCanDraw)
    {
        _isCanDraw = isCanDraw;
    }
}