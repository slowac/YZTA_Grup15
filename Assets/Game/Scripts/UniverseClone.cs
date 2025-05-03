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

        Transform charactersRoot = transform.Find("Characters");
        if (charactersRoot == null) charactersRoot = transform; // fallback

        Instantiate(clonePrefab, player.transform.position, Quaternion.identity, charactersRoot);

        hasSpawned = true;
        usesLeft--;
    }
}
