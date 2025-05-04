using UnityEngine;

public class Unlocker : MonoBehaviour
{
    public GameObject targetObject;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(true);
            Debug.Log("��erdeyken a��k.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(false);
            Debug.Log("��k�nca kapand�.");
        }
    }
}