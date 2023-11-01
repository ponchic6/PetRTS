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
        Debug.Log(1);
        _selectorService = selectorService;
        _selectorService.OnChangeSelectRect += SetSelectRect;
        _selectorService.OnStartDraw += SetCanDrawTrue;
        _selectorService.OnFinishDraw += SetCanDrawFalse;
    }

    private void SetSelectRect(Rect rect)
    {
        _rect = rect;
    }

    private void OnGUI()
    {    
        if (_isCanDraw)
            GUI.Box(_rect, "");
    }

    private void SetCanDrawFalse(bool isCanDraw)
    {
        _isCanDraw = isCanDraw;
    }

    private void SetCanDrawTrue(bool isCanDraw)
    {
        _isCanDraw = isCanDraw;
    }
}