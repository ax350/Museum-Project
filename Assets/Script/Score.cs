using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public FrameSwitcher frameSwitcher;
    public CatSpeaker catSpeaker;
    public GameObject retryButton;

    public List<GameObject> correctPaintings;
    [SerializeField]
    private List<string> correctList;

    private int stars;
    private string feedback;

    private void Awake()
    {
        createCorrectList();
        stars = 3;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkAnswers()
    {
        bool flag = true;

        catSpeaker.transform.parent.gameObject.SetActive(true);
        catSpeaker.turnObjects(false);

        string[] answer_name = frameSwitcher.checkAllFrame();
        foreach (var i in answer_name)
        {
            Debug.Log("Now checking: " + i);
            flag = true;
            foreach (var j in correctList)
            {
                if (i != j)
                {
                    Debug.Log("Keep checking... " + "j: " + j);
                    flag = false;
                    continue;
                }
                else
                {
                    Debug.Log("Right!");
                    flag = true;
                    break;
                }
                
            }
            if (!flag)
            {
                Debug.Log("Logging wrong answer...");
                gradeDown(i);
            }
        }

        if (stars == 3)
        {
            catSpeaker.scoreLine("Perfect!");
        }
        else
        {
            catSpeaker.scoreLine(feedback);
        }

        retryButton.SetActive(true);
    }

    private void createCorrectList()
    {
        correctList = new List<string>();

        foreach (var i in correctPaintings)
        {
            Debug.Log(i.name);
            Debug.Log(i.GetComponent<DragnDrop>().info[0]);
            correctList.Add(i.GetComponent<DragnDrop>().info[0]);
        }
    }

    public void gradeDown(string painting)
    {
        Debug.Log("Wrong Answer:" + painting);
        stars -= 1;
        feedback += painting + " shouldn't be here!" + "\n";
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
