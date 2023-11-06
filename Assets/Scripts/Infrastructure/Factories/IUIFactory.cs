using UnityEngine;

public interface IUIFactory
{
    public Transform CreatCanvas();
    public Transform CreatBuildingListPanel();
    public Transform CreateBuildButtons();
    public Transform CreatePanelOfSelectedObjects();
    public Transform CreateIconOnSelectPanel(ViewSelectStatusChange unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChange unit);
}