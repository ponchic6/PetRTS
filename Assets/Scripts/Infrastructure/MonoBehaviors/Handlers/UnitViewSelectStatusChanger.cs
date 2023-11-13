using UnityEngine;

public class UnitViewSelectStatusChanger : ViewSelectStatusChanger
{
    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _deselectColor;

    public override void Select()
    {
        base.Select();
        GetComponent<MeshRenderer>().material.color = _selectColor;
    }

    public override void Deselect()
    {
        base.Deselect();
        GetComponent<MeshRenderer>().material.color = _deselectColor;
    }
}