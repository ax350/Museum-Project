using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;
    //private Image image;
    [SerializeField]
    private GameObject Hint;
    public void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        //image = GetComponent<Image>();
    }
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        var currentObject = eventData.pointerDrag;
        var object_rectTransform = currentObject.GetComponent<RectTransform>();
        if (currentObject != null)
        {
            //currentObject.transform.SetParent(transform);
            currentObject.GetComponent<DragnDrop>().changeParent(transform);
            object_rectTransform.anchoredPosition = rectTransform.anchoredPosition + new Vector2(rectTransform.sizeDelta.x/2, -rectTransform.sizeDelta.y/2);
        }

        //activeSelf(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeSelf(bool cmd)
    {
        //image.SetEnabled(cmd);
        Hint.SetActive(cmd);
    }
}
