using UnityEngine;

public class UniverseReverse : MonoBehaviour
{
    private bool isReversed = false;

    public bool IsReversed => isReversed;

    public void ToggleReverse()
    {
        isReversed = !isReversed;
    }
}
