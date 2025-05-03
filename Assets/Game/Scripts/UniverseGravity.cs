using UnityEngine;

public class UniverseGravity : MonoBehaviour
{
    private bool gravityFlipped = false;
    public float gravityStrength = 9.81f;

    public bool IsGravityFlipped => gravityFlipped;

    public void ToggleGravity()
    {
        gravityFlipped = !gravityFlipped;

        foreach (var clone in GetComponentsInChildren<PlayerClone>())
        {
            clone.SetGravityDirection(gravityFlipped ? Vector3.up : Vector3.down);
        }
    }
}
