using UnityEngine;

public class SelectorHandler
{
    private UIFactory _uiFactory;
    private IInputService _inputService;
    private Transform _selector;
    
    public SelectorHandler(UIFactory uiFactory, IInputService inputService)
    {
        _uiFactory = uiFactory;
        
        _inputService = inputService;
        _inputService.OnLeftClick += CreateSelector;
    }

    private void CreateSelector()
    {
        _selector = _uiFactory.CreateSelectRectangle();
    }
}