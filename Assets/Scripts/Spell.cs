using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class Spell : ScriptableObject
{
    public string spellName;
    public Sprite spellIcon;
    public float cooldownTime;
    public GameObject spellPrefab;
}
