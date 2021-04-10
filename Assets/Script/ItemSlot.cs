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

            checkSame(currentObject, object_rectTransform);
            //currentObject.transform.SetParent(transform);
            
        }
    }

    public void occupation(GameObject painting)
    {
        occupiedObject = painting;
        occupied = true;
    }

    public void deoccupation()
    {
        occupiedObject = null;
        occupied = false;
    }

    private void checkSame(GameObject painting, RectTransform painting_rectTransform)
    {
        if (occupied)
        {
            if (occupiedObject != painting)
            {
                painting.GetComponent<DragnDrop>().ResetToOriginalPos();
            }
            else
            {
                setPainting(painting, painting_rectTransform);
            }
        }
        else
        {
            setPainting(painting, painting_rectTransform);
        }
    }

    private void setPainting(GameObject currentObject, RectTransform object_rectTransform)
    {
        currentObject.GetComponent<DragnDrop>().changeParent(transform, false);

        object_rectTransform.localScale = new Vector3(2, 2, 2);
        object_rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(rectTransform.sizeDelta.x / 2, -rectTransform.sizeDelta.y / 2);

        occupation(currentObject);
    }

    public void Update()
    {
        if (occupied)
        {
            transform.Find("Hint").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("Hint").gameObject.SetActive(true);
        }
    }
}
