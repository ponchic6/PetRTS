using UnityEngine;

public class UnitConfig : MonoBehaviour
{
    [SerializeField] private Sprite _creationIcon;
    [SerializeField] private WarriorType _warriorType;
    public Sprite CreationIcon => _creationIcon;
    public WarriorType Type => _warriorType;
}