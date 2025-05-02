using System.Collections.Generic;
using UnityEngine;

public class RewindRecorder : MonoBehaviour
{
    private List<Vector3> positionHistory = new List<Vector3>();
    private bool isRewinding = false;
    private Rigidbody rb;

    [Header("Settings")]
    public int maxFrames = 1015; // yaklasik 3sn tekabul ediyor sanirim

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isRewinding)
        {
            RewindTick();
        }
        else
        {
            RecordPosition();
        }

        if(isRewinding)
        {
            Debug.Log("Rewinding!");
        }
    }

    void RecordPosition()
    {
        if (positionHistory.Count > maxFrames)
            positionHistory.RemoveAt(0);

        positionHistory.Add(transform.position);
    }

    void RewindTick()
    {
        if (positionHistory.Count > 0)
        {
            transform.position = positionHistory[^1];
            positionHistory.RemoveAt(positionHistory.Count - 1);
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }

    public bool IsRewinding() => isRewinding;
}
