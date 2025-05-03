using UnityEngine;
using TMPro;

public class AbilityUIHandler : MonoBehaviour
{
    public enum AbilityType { Pause, Rewind, Clone, GravityFlip }
    public AbilityType abilityType;

    [SerializeField] private GameObject universeRoot; // uni 1 or uni 2
    [SerializeField] private TextMeshProUGUI textElement;

    private int currentUsesLeft = -1;

    void Update()
    {
        if (textElement == null || universeRoot == null) return;

        int value = GetAbilityUsesLeft(universeRoot);

        if (value != currentUsesLeft)
        {
            currentUsesLeft = value;
            textElement.text = value.ToString();
        }
    }

    private int GetAbilityUsesLeft(GameObject root)
    {
        switch (abilityType)
        {
            case AbilityType.Pause:
                var pause = root.GetComponent<UniversePause>();
                return pause != null ? pause.usesLeft : 0;

            case AbilityType.Rewind:
                var rewind = root.GetComponent<UniverseRewind>();
                return rewind != null ? rewind.usesLeft : 0;

            case AbilityType.Clone:
                var clone = root.GetComponent<UniverseClone>();
                return clone != null ? clone.usesLeft : 0;

            case AbilityType.GravityFlip:
                var gravity = root.GetComponent<UniverseGravity>();
                return gravity != null ? gravity.usesLeft : 0;

            default:
                return 0;
        }
    }
}
