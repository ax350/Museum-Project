using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatSpeaker : MonoBehaviour
{
    public GameObject[] disableOjects;
    [SerializeField]
    private GameObject talkBar;

    public string[] lines;
    int i = 0;


    // Start is called before the first frame update
    void Start()
    {
        turnObjects(false);
        talkBar.GetComponent<TextMeshProUGUI>().SetText(lines[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            talkCat();
        }
    }

    void talkCat()
    {
        i++;
        if (checkBound(i))
        {
            talkBar.GetComponent<TextMeshProUGUI>().SetText(lines[i]);
        }
    }

    bool checkBound(int i)
    {
        if (i == lines.Length)
        {
            turnObjects(true);
            transform.parent.gameObject.SetActive(false);
            return false;
        }
        else return true;
    }

    public void turnObjects(bool cmd)
    {
        foreach (var i in disableOjects)
        {
            i.SetActive(cmd);
        }
    }

    public void scoreLine(string line)
    {
        talkBar.GetComponent<TextMeshProUGUI>().SetText(line);
    }
}
