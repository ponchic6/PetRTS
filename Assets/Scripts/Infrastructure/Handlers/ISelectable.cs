using UnityEngine;
using UnityEngine.UI;

public interface ISelectable
{
    public Transform GetTransform();
    public bool IsSelect();
    public void Select();
    public void Deselect();
    public Image GetIcon();
}