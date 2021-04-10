using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitcher : MonoBehaviour
{
    [SerializeField]
    private List<ItemSlot> frames;

    public GameObject submitButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeSubmission(submitButton);
    }

    public void activeNext()
    {
        int j = 0;
        foreach (var i in frames)
        {
            if (i.gameObject.activeInHierarchy)
            {
                i.gameObject.SetActive(false);
                j = frames.IndexOf(i);
                Debug.Log(j+" "+frames.Count);
            }
        }
        if (j == frames.Count-1)
        {
            frames[0].gameObject.SetActive(true);
        }
        else
        {
            frames[++j].gameObject.SetActive(true);
            Debug.Log(j+" Working");
        }
    }
    public void activePre()
    {
        int j = 0;
        foreach (var i in frames)
        {
            if (i.gameObject.activeInHierarchy)
            {
                i.gameObject.SetActive(false);
                j = frames.IndexOf(i);
                Debug.Log(j+ " " + frames.Count);
            }
        }
        if (j == 0)
        {
            frames[frames.Count-1].gameObject.SetActive(true);
        }
        else
        {
            frames[--j].gameObject.SetActive(true);
            Debug.Log(j+" Working");
        }
    }

    private void activeSubmission(GameObject button)
    {
        int j = 0;
        foreach (var i in frames)
        {
            if (i.occupied)
            {
                j++;
                continue;
            }
            else
                break;
        }
        if (j == frames.Count)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public string[] checkAllFrame()
    {
        string[] answers;
        answers = new string[frames.Count];
        int a = 0;
        foreach (var i in frames)
        {
            answers[a++] = i.occupiedObject.GetComponent<DragnDrop>().info[0];
        }
        foreach (var i in answers)
        {
            Debug.Log(i);
        }
        Debug.Log(answers);
        return answers;
    }
}
