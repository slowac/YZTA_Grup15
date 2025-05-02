using System.Collections.Generic;
using UnityEngine;

public class ParallelInputManager : MonoBehaviour
{
    private List<PlayerClone> clones = new List<PlayerClone>();

    void Start()
    {
        clones.AddRange(Object.FindObjectsByType<PlayerClone>(FindObjectsSortMode.None));
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool crouch = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);

        foreach (var clone in clones)
        {
            clone.ReceiveInput(move, jump, crouch);
        }
    }
}