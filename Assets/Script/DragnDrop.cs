using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private GameObject parentPanel;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentPanel = this.transform.parent.gameObject;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        Cursor.visible = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .5f;

        if (parentPanel.name == "Frame")
        {
            parentPanel.GetComponent<ItemSlot>().activeSelf(true);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        //Debug.Log(eventData.delta / canvas.scaleFactor + " " + eventData.delta + " " + canvas.scaleFactor);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        Cursor.visible = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    throw new System.NotImplementedException();
    //}

    public void changeParent(Transform input)
    {
        transform.SetParent(input);
        parentPanel = input.gameObject;
    }
}
