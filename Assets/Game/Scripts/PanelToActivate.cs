using UnityEngine;

public class PanelToActivate: MonoBehaviour
{
    public GameObject panelToActivate;

    private void OnDisable()
    {
        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }
}