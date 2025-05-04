using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(false);
            Debug.Log("��erdeyken a��k.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(true);
            Debug.Log("��k�nca kapand�.");
        }
    }
}