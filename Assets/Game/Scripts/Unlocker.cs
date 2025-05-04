using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(true);
            Debug.Log("Ýçerdeyken açýk.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(false);
            Debug.Log("Çýkýnca kapandý.");
        }
    }
}