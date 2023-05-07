using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverBasic : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void HoverEvent();

    public HoverEvent hoverEnterEvent;
    public HoverEvent hoverLeaveEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverEnterEvent.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverLeaveEvent.Invoke();
    }

}
