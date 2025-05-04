using UnityEngine;

public class UniverseClone : MonoBehaviour
{
    public GameObject clonePrefab;
    public int usesLeft = 1;
    private bool hasSpawned = false;

    public void SpawnClone()
    {
        if (usesLeft <= 0 || hasSpawned) return;

        var player = GetComponentInChildren<PlayerClone>();
        if (player == null) return;

        Transform charactersRoot = null;

        var playerContainer = transform.Find("PlayerContainer");
        if (playerContainer != null)
        {
            charactersRoot = playerContainer.Find("Characters");
        }

        if (charactersRoot == null)
        {
            charactersRoot = transform.Find("Characters");
        }

        if (charactersRoot == null)
        {
            Debug.LogWarning("Characters objesi bulunamadý, Universe'e atýlýyor.");
            charactersRoot = transform;
        }

        GameObject clone = Instantiate(clonePrefab, player.transform.position, Quaternion.identity, charactersRoot);
        Destroy(clone, 7f);

        hasSpawned = true;
        usesLeft--;
    }

}
