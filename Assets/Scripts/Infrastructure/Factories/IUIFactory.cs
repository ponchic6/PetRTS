using UnityEngine;

public interface IUIFactory
{   
    public Transform RootCanvas { get; }
    public Transform CreationPannel { get; }
    public Transform BuildingButtons { get; }
    public Transform PanelOfSelected { get; }
    public Transform CreatCanvas();
    public Transform CreatBuildingListPanel();
    public Transform CreateBuildButtons();
    public Transform CreateUnitButton(UnitConfig unit);
    public Transform CreatePanelOfSelectedObjects();
    public Transform CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}