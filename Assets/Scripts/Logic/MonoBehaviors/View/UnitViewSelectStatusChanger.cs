using UnityEngine;

public class UnitViewSelectStatusChanger : ViewSelectStatusChanger
{
    [SerializeField] private GameObject _selectRing;

    public override void Select()
    {
        base.Select();
        _selectRing.SetActive(true);
    }

    public override void Deselect()
    {
        base.Deselect();
        _selectRing.SetActive(false);
    }
}