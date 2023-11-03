using UnityEngine;

public interface IUIFactory
{
    public Transform CreatCanvas();
    public Transform CreatBuildingListPanel();
    public Transform CreateBuildButtons();
    public Transform CreatePanelOfSelectedObjects();
    public Transform CreateIconInSelectPanel(ISelectable unit);
    public void DestroyIconInSelectPanel(ISelectable unit);
}