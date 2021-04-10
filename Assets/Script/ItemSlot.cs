using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;

    public GameObject occupiedObject;
    public bool occupied;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        var currentObject = eventData.pointerDrag;
        var object_rectTransform = currentObject.GetComponent<RectTransform>();
        if (eventData.pointerDrag != null && eventData.pointerDrag.name == "Image")
        {
            //currentObject.transform.SetParent(transform);
            currentObject.GetComponent<DragnDrop>().changeParent(transform, false);

            object_rectTransform.localScale = new Vector3(2, 2, 2);
            object_rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(rectTransform.sizeDelta.x/2, -rectTransform.sizeDelta.y/2);

            occupiedObject = currentObject;
            occupied = true;
        }
    }
}
