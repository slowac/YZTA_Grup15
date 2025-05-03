using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager tooltip = Object.FindFirstObjectByType<TooltipManager>();
        if (tooltip != null)
            tooltip.ShowTooltip(message);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager tooltip = Object.FindFirstObjectByType<TooltipManager>();
        if (tooltip != null)
            tooltip.HideTooltip();
    }
}