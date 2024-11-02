using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Questlog : MonoBehaviour
{
    [SerializeField]
    private GameObject questPrelaf;


    [SerializeField]
    private Transform questParent;

    private Quest selected;

    [SerializeField]
    private Text questDescription;

    private static Questlog instance;

    public static Questlog MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Questlog>();
            }
            return instance;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AcceptQuest(Quest quest)
    {
        GameObject go = Instantiate(questPrelaf, questParent);

        QuestScript qs = go.GetComponent<QuestScript>();
        quest.MyQuestScript = qs;
        qs.MyQuest = quest;
      

        go.GetComponent<Text>().text = quest.MyTitle; 
    }
    public void ShowDescription(Quest quest)
    {
        if (selected != null)
        {
            selected.MyQuestScript.DeSelect();
        }
        string objectives = string.Empty;

        selected = quest;

        string title = quest.MyTitle;

        foreach (Objective obj in quest.MyCollectObjectives)
        {
            objectives += obj.MyType + ": " + obj.MyCurrentAmount + "/" + obj.MyAmount + "\n";
        }

        questDescription.text = string.Format("{0}\n<size=10>{1}</size>\nObjectives\n<size=10>{2}</size>", title,quest.MyDescription,objectives);
    }
}
