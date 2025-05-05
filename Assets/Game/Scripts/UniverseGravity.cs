using UnityEngine;

public class UniverseGravity : MonoBehaviour
{
    private bool gravityFlipped = false;
    public float gravityStrength = 9.81f;
    public int usesLeft = 2; // KULLANIM HAKKI

    public bool IsGravityFlipped => gravityFlipped;

    public void ToggleGravity()
    {
        if (usesLeft <= 0) return;

        gravityFlipped = !gravityFlipped;
        usesLeft--;

        foreach (var clone in GetComponentsInChildren<PlayerClone>())
        {
            clone.SetGravityDirection(gravityFlipped ? Vector3.up : Vector3.down);
        }

        SoundManager.Instance.PlayGravitySFX();
    }
}
