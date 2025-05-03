using System.Collections;
using UnityEngine;

public class UniversePause : MonoBehaviour
{
    public int usesLeft = 2;
    public bool IsPaused { get; private set; } = false;

    public void TriggerPause()
    {
        if (usesLeft > 0 && !IsPaused)
        {
            StartCoroutine(PauseCoroutine());
        }
    }

    private IEnumerator PauseCoroutine()
    {
        IsPaused = true;
        usesLeft--;

        // freeze chars
        foreach (var clone in GetComponentsInChildren<PlayerClone>())
        {
            clone.SetFrozen(true);
        }

        yield return new WaitForSeconds(2f);

        // unfreeze
        foreach (var clone in GetComponentsInChildren<PlayerClone>())
        {
            clone.SetFrozen(false);
        }

        IsPaused = false;
    }
}
