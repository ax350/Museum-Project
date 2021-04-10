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
    private GameObject parentObject;

    public string[] info;

    public Vector2 originalPos;

    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        parentObject = transform.parent.gameObject;
        UpdatePos();
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
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        
        Cursor.visible = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
    }

    public void changeParent(Transform parent, bool cmd)
    {
        if (parentObject.name == "Menu")
        {
            parentObject.GetComponent<Menu>().removeFromList(this.gameObject);
        }
        else if (parentObject.name == "Frame")
        {
            parentObject.GetComponent<ItemSlot>().deoccupation();
        }
        transform.SetParent(parent, cmd);
        if (parent != null)
        {
            parentObject = parent.gameObject;
        }     
    }

    private void UpdatePos()
    {
        originalPos = rectTransform.anchoredPosition;
    }
    public void ResetToOriginalPos()
    {
        transform.SetParent(null);
        transform.SetParent(parentObject.transform);
    }
}
