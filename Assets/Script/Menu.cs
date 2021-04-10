using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IDropHandler
{
    public Dictionary<GameObject,string[]> paintingDirectory;
    public List<GameObject> paintings;

    void Awake()
    { 
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null && eventData.pointerDrag.name == "Image")
        {
            //eventData.pointerDrag.transform.SetParent(null, false);
            //eventData.pointerDrag.transform.SetParent(transform, false);
            eventData.pointerDrag.GetComponent<DragnDrop>().changeParent(null, false);
            eventData.pointerDrag.GetComponent<DragnDrop>().changeParent(transform, false);

            eventData.pointerDrag.GetComponent<RectTransform>().localScale = new Vector3(.5625f, 1, 1);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0,0,1);
            //object_rectTransform.localPosition.z = 1f;
        }
    }

    void readAllPaintings()
    {
        for (int i = 0; i< transform.childCount; i++)
        {
            GameObject painting = transform.GetChild(i).gameObject;
            paintings.Add(painting);
            paintingDirectory.Add(painting, painting.GetComponent<DragnDrop>().info);
        }
    }
}
