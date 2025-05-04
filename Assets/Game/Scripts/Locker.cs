using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject objectToLock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToLock.SetActive(false);
            Debug.Log("Kapý kilitlendi!");
            Destroy(gameObject);
        }
    }
}