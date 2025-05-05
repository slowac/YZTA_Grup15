using UnityEngine;
using System.Collections;

public class UniverseRewind : MonoBehaviour
{
    public int usesLeft = 2;
    private bool isRewinding = false;
    public float maxRewindDuration = 3f;

    private float rewindTimer = 0f;

    void Update()
    {
        if (isRewinding)
        {
            rewindTimer += Time.deltaTime;

            if (rewindTimer >= maxRewindDuration)
            {
                StopRewind();
            }
        }
    }

    public void StartRewind()
    {
        if (usesLeft > 0 && !isRewinding)
        {
            usesLeft--;
            isRewinding = true;
            rewindTimer = 0f;

            SoundManager.Instance.PlayRewindSFX();

            foreach (var rewind in GetComponentsInChildren<RewindRecorder>())
            {
                rewind.StartRewind();
            }
        }
    }

    public void StopRewind()
    {
        if (!isRewinding) return;

        isRewinding = false;

        SoundManager.Instance.StopRewindSFX();

        foreach (var rewind in GetComponentsInChildren<RewindRecorder>())
        {
            rewind.StopRewind();
        }
    }
}
