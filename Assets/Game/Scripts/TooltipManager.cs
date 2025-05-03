using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour
{
    public TextMeshProUGUI tooltipText;
    public GameObject tooltipPanel;
    public Vector2 offset = new Vector2(10f, 20f);

    private RectTransform panelRectTransform;


    void Awake()
    {
        panelRectTransform = tooltipPanel.GetComponent<RectTransform>();
        tooltipPanel.SetActive(false);
    }

    void Update()
    {
        if (tooltipPanel.activeSelf)
        {
            Vector2 mousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                tooltipPanel.transform.parent as RectTransform,
                Input.mousePosition, null, out mousePos);
            panelRectTransform.anchoredPosition = mousePos + offset;
        }
    }

    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipPanel.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipPanel.SetActive(false);
    }
}
