using UnityEngine;

public class UniverseRestart : MonoBehaviour
{
    public void RestartUniverse(GameObject playerObj)
    {
        if (playerObj == null) return;

        PlayerClone player = playerObj.GetComponent<PlayerClone>();
        Universe universe = playerObj.GetComponentInParent<Universe>();

        if (player == null || universe == null || universe.spawnPoint == null) return;

        player.transform.position = universe.spawnPoint.position;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = Vector3.zero;
    }
}
