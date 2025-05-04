using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(false);
            Debug.Log("Ýçerdeyken açýk.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(true);
            Debug.Log("Çýkýnca kapandý.");
        }
    }
}