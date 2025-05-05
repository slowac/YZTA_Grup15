using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerClone clone = other.GetComponent<PlayerClone>();
        if (clone != null && !clone.IsInTeleportCooldown())
        {
            Universe universe = clone.myUniverse;
            if (universe != null && universe.spawnPoint != null)
            {
                SoundManager.Instance.PlayRespawnSFX();
                clone.TeleportTo(universe.spawnPoint.position);
            }
        }
    }
}
